using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET5
{
    public static class TokenExtensions
    {

        //public static IApplicationBuilder UseToken(this IApplicationBuilder builder)
        //{
        //    return builder.UseMiddleware<TokenMiddleware>();
        //}
        //**************************

        // извне  получение токина
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern)
        {
            return builder.UseMiddleware<TokenMiddleware>(pattern);
        }
    }
}
