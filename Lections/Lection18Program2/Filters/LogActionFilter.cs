using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lection18Program2.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.StatusCode = 200;
            using (var writer = new StreamWriter(context.Response.Body))
            {
                await writer.WriteLineAsync("Done!");
                return;
            }
        }

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var message = $"Executing action {actionName} on controller {controllerName}.\n";

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var message = $"Executed action {actionName} on controller {controllerName}.\n";

            base.OnActionExecuted(context);
        }
        
        
    }
}

