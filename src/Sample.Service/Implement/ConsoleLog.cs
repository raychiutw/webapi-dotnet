using System;
using Sample.Service.Interface;

namespace Sample.Service.Implement
{
    public class ConsoleLog : ILog
    {
        /// <summary>
        /// 儲存 Log
        /// </summary>
        /// <param name="message">Log 訊息</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Save(string message)
        {
            Console.WriteLine($"[{DateTime.Now}]{message}");
        }
    }
}