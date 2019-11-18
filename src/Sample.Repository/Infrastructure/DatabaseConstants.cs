using System.Data;
using System.Data.SqlClient;
using EF.Diagnostics.Profiling;
using EF.Diagnostics.Profiling.Data;

namespace Sample.Repository.Infrastructure
{
    /// <summary>
    /// Database 介面
    /// </summary>
    public class DatabaseConstants : IDatabaseConstants
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConstants"/> class.
        /// </summary>
        /// <param name="connectionString">The database.</param>
        public DatabaseConstants(string connectionString)
        {
            this._connectionString = connectionString;
        }

        /// <summary>
        /// 取得連線
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetConnection()
        {
            var connection = new SqlConnection(this._connectionString);

            if (ProfilingSession.Current == null)
            {
                return connection;
            }

            var dbProfiler = new DbProfiler(ProfilingSession.Current.Profiler);
            return new ProfiledDbConnection(connection, dbProfiler);
        }
    }
}