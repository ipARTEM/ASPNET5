using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A009RouterMiddleware
{
    public class RouteHandler : IRouteHandler //, IRouter
    {
        private readonly RequestDelegate _requestDelegate;

        public RouteHandler(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public RequestDelegate GetRequestHandler(HttpContext httpContext, RouteData routeData)
        {
            throw new NotImplementedException();
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            throw new NotImplementedException();
        }

        

        //public Task RouteAsync(RouteContext context)
        //{
        //    context.Handler = _requestDelegate;
        //    return TaskCache.CompletedTask;
        //}
    }
}
