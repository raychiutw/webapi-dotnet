using System.Data.Common;
using System.Data.SqlClient;

namespace Sample.Repository.Infrastructure
{
    /// <summary>
    /// Database 介面
    /// </summary>
    /// <seealso cref="Evertrust.Mail.Repository.Infrastructure.IDatabaseConstants" />
    public class DatabaseConstants : IDatabaseConstants
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConstants"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public DatabaseConstants(string connectionString)
        {
            this._connectionString = connectionString;
        }

        /// <summary>
        /// 取得連線
        /// </summary>
        /// <returns></returns>
        public DbConnection GetConnection()
        {
            var connection = new SqlConnection(this._connectionString);

            return connection;
        }
    }
}