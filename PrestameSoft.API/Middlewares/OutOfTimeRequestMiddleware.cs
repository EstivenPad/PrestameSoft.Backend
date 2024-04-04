using Newtonsoft.Json;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using PrestameSoft.Domain;
using System.IO;
using System.Text;

namespace PrestameSoft.API.Middlewares
{
    public class OutOfTimeRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public OutOfTimeRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IPaymentRepository paymentRepository)
        {
            if (httpContext.Request.Method == "PUT" && httpContext.Request.Path == "/api/Payment")
            {
                //Enable multiple reads
                httpContext.Request.EnableBuffering();
                    
                //Convert the Stream into a JSON string to take the request's body
                string requestBody = await new StreamReader(httpContext.Request.Body, Encoding.UTF8).ReadToEndAsync();
                    
                //Relocate the position of the Stream
                httpContext.Request.Body.Position = 0;
                    
                //Deserialize JSON string into a domain entity
                Payment paymentDeserialized = JsonConvert.DeserializeObject<Payment>(requestBody);
      
                //Get the payment from the database
                var paymentDB = await paymentRepository.GetByIdAsync(paymentDeserialized.Id);

                if (paymentDB is null)
                    throw new NotFoundException(nameof(paymentDB), paymentDeserialized.Id);

                DateTime now = DateTime.Now;
                DateTime paymentTime = paymentDB.DateCreated.Value;

                TimeSpan timeDifference = now - paymentTime;

                if(timeDifference.TotalMinutes <= 30)
                    await _next(httpContext);
                else
                    throw new OutOfTimeException();
            }
            else
            {
                await _next(httpContext);
            }
        }
    }
}
