using System.Data.Common;

namespace Sample.Repository.Infrastructure
{
    /// <summary>
    /// Database 介面
    /// </summary>
    public interface IDatabaseConstants
    {
        /// <summary>
        /// 取得連線
        /// </summary>
        /// <param name="connectionString">連線字串</param>
        /// <returns></returns>
        DbConnection GetConnection();
    }
}