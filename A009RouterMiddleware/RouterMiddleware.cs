using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A009RouterMiddleware
{
    public class RouterMiddleware
    {

        
        //public async Task Invoke(HttpContext httpContext)
        //{
        //    var context = new RouteContext(httpContext);
        //    context.RouteData.Routers.Add(_router);

        //    // проверка соответствия строки запроса маршруту
        //    await _router.RouteAsync(context);

        //    // если сопоставление завершилось неудачно
        //    // и делегат не установлен, 
        //    if (context.Handler == null)
        //    {
        //        _logger.RequestDidNotMatchRoutes();
        //        // вызываем следующий компонент middleware
        //        await _next.Invoke(httpContext);
        //    }
        //    else
        //    {
        //        var routingFeature = new RoutingFeature()
        //        {
        //            RouteData = context.RouteData
        //        };

        //        httpContext.Request.RouteValues = context.RouteData.Values;
        //        httpContext.Features.Set<IRoutingFeature>(routingFeature);

        //        await context.Handler(context.HttpContext);
        //    }
        //}
        
    }
}
