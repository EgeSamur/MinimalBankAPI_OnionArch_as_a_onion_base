using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace MinimalBankAPI_OnionArch.Application.Common.CCC.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ExceptionMiddleware()
        {
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true, // Logları daha okunabilir hale getirir
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Json formatında camelCase kullanımı
            };
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);  // Request'i bir sonraki middleware'e gönder
            }
            catch (Exception ex)
            {
                // exception handler 
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            ExceptionModel exceptionModel;

            switch (exception)
            {
                case ValidationException validationException:
                    exceptionModel = new ExceptionModel
                    {
                        Errors = validationException.Errors.Select(x => x.ErrorMessage),
                        StatusCode = StatusCodes.Status422UnprocessableEntity,
                        Title = "Validation Error" // Validation exception için özelleştirilmiş başlık
                    };
                    break;

                case UnauthorizedAccessException _:
                    exceptionModel = new ExceptionModel
                    {
                        Messages = new List<string> { "You are not authorized to perform this action." },
                        StatusCode = StatusCodes.Status401Unauthorized,
                        Title = "Unauthorized" // Unauthorized exception için başlık
                    };
                    break;

                case ForbiddenException _:
                    exceptionModel = new ExceptionModel
                    {
                        Messages = new List<string> { "You do not have permission to access this resource." },
                        StatusCode = StatusCodes.Status403Forbidden,
                        Title = "Forbidden" // Forbidden exception için başlık
                    };
                    break;

                case BadRequestException _:
                    exceptionModel = new ExceptionModel
                    {
                        Messages = new List<string> { exception.Message },
                        StatusCode = StatusCodes.Status400BadRequest,
                        Title = "Bad Request Error" // BadRequestException için başlık
                    };
                    break;

                case NotFoundException _:
                    exceptionModel = new ExceptionModel
                    {
                        Messages = new List<string> { exception.Message },
                        StatusCode = StatusCodes.Status404NotFound,
                        Title = "Not Found Error" // NotFoundException için başlık
                    };
                    break;

                default:
                    exceptionModel = new ExceptionModel
                    {
                        Messages = new List<string> { exception.Message },
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Title = "Internal Server Error" // Diğer exceptionlar için genel başlık
                    };
                    break;
            }

            return httpContext.Response.WriteAsync(exceptionModel.ToString());
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                ForbiddenException => StatusCodes.Status403Forbidden,
                _ => StatusCodes.Status500InternalServerError
            };
    }
}
