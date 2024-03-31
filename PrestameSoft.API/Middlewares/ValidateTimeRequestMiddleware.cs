using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;

namespace PrestameSoft.API.Middlewares
{
    public class ValidateTimeRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidateTimeRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IPaymentRepository paymentRepository)
        {
            if (httpContext.Request.Method == "PUT")
            {
                //var entityId = await httpContext.Request.ReadFormAsync();

                //if (!int.TryParse(entityId?.ToString(), out int id))
                //{
                //    throw new BadRequestException("Invalid request");
                //}

                //var entity = await _paymentRepository.GetByIdAsync(id);

                //if (entity is null)
                //    throw new NotFoundException(nameof(entity), id);

                //var hour = TimeOnly.Parse(entity.DateCreated.ToString());
                //await Console.Out.WriteLineAsync(hour.ToString());
                await Console.Out.WriteLineAsync("PUT METHOD =====>");
            }

            await _next(httpContext);
        }
    }
}
