using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrestameSoft.Application.Features.Client.Commands.CreateClient;
using PrestameSoft.Application.Features.Client.Commands.DeleteClient;
using PrestameSoft.Application.Features.Client.Commands.InactiveClient;
using PrestameSoft.Application.Features.Client.Commands.UpdateClient;
using PrestameSoft.Application.Features.Client.Queries.GetAllClients;
using PrestameSoft.Application.Features.Client.Queries.GetClientDetail;

namespace PrestameSoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ClientController>
        [HttpGet]
        public async Task<ActionResult<List<ClientDto>>> Get()
        {
            var clients = await _mediator.Send(new GetClientQuery());
            return Ok(clients);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDetailsDto>> Get(int id)
        {
            var client = await _mediator.Send(new GetClientDetailsQuery(id));
            return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post(CreateClientCommand client)
        {
            var response = await _mediator.Send(client);
            return CreatedAtAction(nameof(Get), new { Id = response });
        }

        // PUT api/<ClientController>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateClientCommand client)
        {
            await _mediator.Send(client);
            return NoContent();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Inactive(int id)
        {
            var command = new InactiveClientCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(DeleteClientCommand client)
        {
            await _mediator.Send(client);
            return NoContent();
        }
    }
}
