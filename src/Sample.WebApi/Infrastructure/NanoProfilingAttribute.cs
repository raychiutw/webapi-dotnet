using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using EF.Diagnostics.Profiling;

namespace Sample.Infrastructure
{
    /// <summary>
    /// NanoProfilingAttribute
    /// </summary>
    /// <seealso cref="System.Web.Http.Filters.ActionFilterAttribute" />
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
        /// Called when [action executing].
        /// </summary>
        /// <param name="context">The context.</param>
        public override void OnActionExecuting(HttpActionContext context)
        {
            base.OnActionExecuting(context);

            if (string.IsNullOrWhiteSpace(this.ProfilingName))
            {
                this.ProfilingName = $"Web Controller Profilier";
            }

            this.ProfilingStep = ProfilingSession.Current.Step(this.ProfilingName);
        }

        /// <summary>
        /// Called when [action executed].
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuted(HttpActionExecutedContext actionContext)
        {
            base.OnActionExecuted(actionContext);
            this.ProfilingStep?.Dispose();
        }
    }
}