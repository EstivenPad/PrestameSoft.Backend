using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrestameSoft.Application.Features.Payment.Commands.CreatePayment;
using PrestameSoft.Application.Features.Payment.Commands.DeletePayment;
using PrestameSoft.Application.Features.Payment.Commands.InactivePayment;
using PrestameSoft.Application.Features.Payment.Commands.UpdatePayment;
using PrestameSoft.Application.Features.Payment.Queries.GetAllPayments;
using PrestameSoft.Application.Features.Payment.Queries.GetPaymentDetail;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrestameSoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PaymentController>
        [HttpGet]
        public async Task<ActionResult<List<PaymentDto>>> Get()
        {
            var payments = await _mediator.Send(new GetPaymentQuery());
            return Ok(payments);
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetailsDto>> Get(int id)
        {
            var payment = await _mediator.Send(new GetPaymentDetailsQuery(id));
            return Ok(payment);
        }

        // POST api/<PaymentController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post(CreatePaymentCommand command)
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { Id = response });
        }

        // PUT api/<PaymentController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdatePaymentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new InactivePaymentCommand { Id = id });
            return NoContent();
        }

        // DELETE api/<PaymentController>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(DeletePaymentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
