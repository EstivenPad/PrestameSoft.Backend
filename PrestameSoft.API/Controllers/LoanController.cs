using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrestameSoft.Application.Features.Loan.Commands.CreateLoan;
using PrestameSoft.Application.Features.Loan.Commands.DeleteLoan;
using PrestameSoft.Application.Features.Loan.Commands.InactiveLoan;
using PrestameSoft.Application.Features.Loan.Commands.UpdateLoan;
using PrestameSoft.Application.Features.Loan.Queries.GetAllLoans;
using PrestameSoft.Application.Features.Loan.Queries.GetLoanDetail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrestameSoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LoanController>
        [HttpGet]
        public async Task<ActionResult<List<LoanDto>>> Get()
        {
            var loans = await _mediator.Send(new GetLoanQuery());
            return Ok(loans);
        }

        // GET api/<LoanController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDetailsDto>> Get(int id)
        {
            var loan = await _mediator.Send(new GetLoanDetailsQuery(id));
            return Ok(loan);
        }

        // POST api/<LoanController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateLoanCommand loan)
        {
            var response = await _mediator.Send(loan);
            return CreatedAtAction(nameof(Get), new { Id = response });
        }

        // PUT api/<LoanController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateLoanCommand loan)
        {
            await _mediator.Send(loan);
            return NoContent();
        }

        // DELETE api/<LoanController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Inactive(int id)
        {
            await _mediator.Send(new InactiveLoanCommand { Id = id });
            return NoContent();
        }

        // DELETE api/<LoanController>/5
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(DeleteLoanCommand loan)
        {
            await _mediator.Send(loan);
            return NoContent();
        }
    }
}
