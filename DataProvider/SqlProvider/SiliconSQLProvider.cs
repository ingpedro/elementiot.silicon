using Dapper;
using ElementIoT.Particle.Operational.Error;
using ElementIoT.Particle.Operational.Logging;
using ElementIoT.Silicon.Resource.Messages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace ElementIoT.Silicon.DataProvider.SqlProvider
{
    /// <summary>
    /// 
    /// </summary>
    public class SiliconSQLProvider
    {
        #region Fields

        private const string DB_CONNECTION_KEY = "Database:ConnectionString";

        #endregion

        #region Properties

        protected IConfiguration ConfigService
        { get; }

        protected IErrorPolicy ErrorService
        { get; }

        protected ILogPolicy LogService
        { get; }

        protected string ConnectionString
        { get; }

        #endregion

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="SiliconSQLProvider"/> class.
        /// </summary>
        /// <param name="configService">The configuration service.</param>
        /// <param name="errorService">The error service.</param>
        /// <param name="logService">The log service.</param>
        /// <exception cref="IoTException"></exception>
        public SiliconSQLProvider(IConfiguration configService, IErrorPolicy errorService, ILogPolicy logService)
        {
            this.ConfigService = configService;
            this.ErrorService = errorService;
            this.LogService = logService;

            //set connection string
            if (!string.IsNullOrWhiteSpace(ConfigService[DB_CONNECTION_KEY])) {
                this.ConnectionString = ConfigService[DB_CONNECTION_KEY];               
            }
            else
            {
                throw new IoTException(ErrorMessages.DataProvider_ConnectionStringKeyMissing, ErrorReasonTypeEnum.Configuration);
            }

            
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        protected virtual async Task<int> ExecuteAsync(CommandDefinition command)
        {
            try
            {
                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    return await connection.ExecuteAsync(command);
                }
            }
            catch (Exception ex)
            {
                LogService.LogError(new LogEntry() { Error = ex });

                throw;
            }
        }

        /// <summary>
        /// Queries a single item from the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        protected virtual async Task<T> QuerySingleAsync<T>(CommandDefinition command) where T : class
        {
            try
            {
                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    return await connection.QuerySingleOrDefaultAsync<T>(command);
                }
            }
            catch (Exception ex)
            {
                LogService.LogError(new LogEntry() { Error = ex });

                throw;
            }
        }


        /// <summary>
        /// Queries a list of items from the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        protected virtual async Task<IEnumerable<T>> QueryAsync<T>(CommandDefinition command) where T : class
        {
            try
            {
                IEnumerable<T> results;

                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    results = await connection.QueryAsync<T>(command);
                }

                return results;
            }
            catch (Exception ex)
            {
                LogService.LogError(new LogEntry() { Error = ex });

                throw;
            }
        }

        /// <summary>
        /// Queries a list of items from the database and uses the given converter to transform the results into another type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        protected virtual async Task<IEnumerable<T>> QueryAsync<T>(CommandDefinition command, Func<dynamic, T> converter) where T : class
        {
            try
            {
                IEnumerable<dynamic> results;

                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    results = await connection.QueryAsync(command);
                }

                return results.Select(r => converter(results));
            }
            catch (Exception ex)
            {
                LogService.LogError(new LogEntry() { Error = ex });

                throw;
            }
        }



        /// <summary>
        /// Queries a list of multiple results sets from the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        protected virtual async Task<IEnumerable<T>> QueryMultipleAsync<T>(CommandDefinition command) where T : class
        {
            try
            {
                IEnumerable<T> results;
                SqlMapper.GridReader multiResults;

                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();

                    multiResults = await connection.QueryMultipleAsync(command);

                    results = await multiResults.ReadAsync<T>();

                }

                return results;
            }
            catch (Exception ex)
            {
                LogService.LogError(new LogEntry() { Error = ex });

                throw;
            }
        }

        protected virtual async Task<SqlMapper.GridReader> QueryMultipleAsync(CommandDefinition command)
        {
            try
            {
                SqlMapper.GridReader multiResultReader;

                var connection = new SqlConnection(this.ConnectionString);
                connection.Open();

                multiResultReader = await connection.QueryMultipleAsync(command);

                return multiResultReader;
            }
            catch (Exception ex)
            {
                LogService.LogError(new LogEntry() { Error = ex });

                throw;
            }
        }

        #endregion
    }
}
