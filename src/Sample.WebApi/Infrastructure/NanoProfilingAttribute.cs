using System;
using System.Web.Mvc;
using EF.Diagnostics.Profiling;

namespace Sample.Infrastructure
{
    /// <summary>
    /// Class NanoProfilingAttribute.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.ActionFilterAttribute" />
    public class NanoProfilingAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// ProfilingName.
        /// </summary>
        /// <value>The name of the profiling.</value>
        public string ProfilingName { get; set; }

        /// <summary>
        /// ProfilingStep.
        /// </summary>
        /// <value>The profiling step.</value>
        public IDisposable ProfilingStep { get; set; }

        /// <summary>
        /// 在動作方法執行之前，由 ASP.NET MVC 架構呼叫。
        /// </summary>
        /// <param name="filterContext">篩選內容。</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (string.IsNullOrWhiteSpace(this.ProfilingName))
            {
                var controllerName = filterContext.RequestContext.RouteData.Values["controller"] == null
                    ? string.Empty
                    : filterContext.RequestContext.RouteData.Values["controller"].ToString().ToLower();

                var actionName = filterContext.RequestContext.RouteData.Values["action"] == null
                    ? string.Empty
                    : filterContext.RequestContext.RouteData.Values["action"].ToString().ToLower();

                this.ProfilingName = $"Web [controller : {controllerName}][action : {actionName}]";
            }

            this.ProfilingStep = ProfilingSession.Current.Step(this.ProfilingName);
        }

        /// <summary>
        /// 在動作方法執行之後，由 ASP.NET MVC 架構呼叫。
        /// </summary>
        /// <param name="filterContext">篩選內容。</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            this.ProfilingStep?.Dispose();
        }
    }
}