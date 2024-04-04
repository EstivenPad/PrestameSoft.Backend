using PrestameSoft.API.Model;
using PrestameSoft.Application.Exceptions;
using System.Net;

namespace PrestameSoft.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next) 
        {
            _next = next;        
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            CustomValidationProblemDetails problem = new();

            switch (ex)
            {
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    problem = new CustomValidationProblemDetails()
                    {
                        Title = badRequestException.Message,
                        Status = (int)statusCode,
                        Type = nameof(BadRequestException),
                        Detail = badRequestException.InnerException?.Message,
                        Errors = badRequestException.ValidationErrors
                    };
                    break;

                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    problem = new CustomValidationProblemDetails()
                    {
                        Title = notFoundException.Message,
                        Status = (int)statusCode,
                        Type = nameof(NotFoundException),
                        Detail = notFoundException.InnerException?.Message
                    };
                    break;

                case OutOfTimeException outOfTimeException:
                    statusCode = HttpStatusCode.Forbidden;
                    problem = new CustomValidationProblemDetails()
                    {
                        Title = outOfTimeException.Message,
                        Status = (int)statusCode,
                        Type = nameof(OutOfTimeException),
                        Detail = outOfTimeException.InnerException?.Message
                    };
                    break;

                default:
                    problem = new CustomValidationProblemDetails()
                    {
                        Title = ex.Message,
                        Status = (int)statusCode,
                        Type = nameof(Exception),
                        Detail = ex.StackTrace
                    };
                    break;
            }

            httpContext.Response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsJsonAsync(problem);
        }
    }
}
