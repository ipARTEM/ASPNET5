using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A010RouteContext
{
    public class PositionConstraint : IRouteConstraint
    {
        string[] positions = new[] { "admin", "director", "accountant" };
        public bool Match(HttpContext httpContext, IRouter route, string routeKey,
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            return positions.Contains(values[routeKey]?.ToString().ToLowerInvariant());
        }
    }
}