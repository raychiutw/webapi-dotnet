namespace Sample.Service.Interface
{
    /// <summary>
    /// Log 介面
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 儲存 Log
        /// </summary>
        /// <param name="message">Log 訊息</param>
        void Save(string message);
    }
}