using Microsoft.AspNetCore.Builder;
using MinimalBankAPI_OnionArch.Application.Common.CCC.Exceptions;

namespace MinimalBankAPI_OnionArch.Application
{
    public static class ExceptionMiddlewareRegistration
    {
        public static void AddConfigureGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
