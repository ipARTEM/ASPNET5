using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A001
{
    public class TimerMiddleware
    {
        private readonly RequestDelegate _next;
        TimeService _timeService;

        //public TimerMiddleware(RequestDelegate next, TimeService timeService)
        //{
        //    _next = next;
        //    _timeService = timeService;
        //}

        //*****************************

        public TimerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //public async Task InvokeAsync(HttpContext context)
        //{
        //    if (context.Request.Path.Value.ToLower() == "/time")
        //    {
        //        context.Response.ContentType = "text/html; charset=utf-8";
        //        await context.Response.WriteAsync($"Текущее время: {_timeService?.Time}");
        //    }
        //    else
        //    {
        //        await _next.Invoke(context);
        //    }
        //}
        //*********************************
        //public async Task Invoke(HttpContext context)
        //{
        //    context.Response.ContentType = "text/html; charset=utf-8";
        //    await context.Response.WriteAsync($"Текущее время: {_timeService?.GetTime()}");
        //}

        //******************************


        public async Task InvokeAsync(HttpContext context, TimeService timeService)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync($"Текущее время: {timeService?.GetTime()}");
        }
    }
}