using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace Sample.WebApi
{
    /// <summary>
    ///
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            // 移除XML格式輸出
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // 對 JSON 資料使用 CamelCase，但是 JaveScript 首字母使用小寫。
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            // Web API 設定和服務

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}