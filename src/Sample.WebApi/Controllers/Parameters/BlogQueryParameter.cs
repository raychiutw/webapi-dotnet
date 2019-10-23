namespace Sample.WebApi.Controllers.Parameters
{
    /// <summary>
    /// Blog Query 參數
    /// </summary>
    public class BlogQueryParameter
    {
        /// <summary>
        /// 起始筆數
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 結束筆數
        /// </summary>
        public int End { get; set; }
    }
}