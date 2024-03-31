using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Client.Commands.InactiveClient
{
    public class InactiveClientCommandHandler : IRequestHandler<InactiveClientCommand, Unit>
    {
        private readonly IClientRepository _clientRepository;

        public InactiveClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Unit> Handle(InactiveClientCommand request, CancellationToken cancellationToken)
        {
            //Retrieve domain entity object
            var clientToInactive = await _clientRepository.GetByIdAsync(request.Id);

            //Verify that record exist
            if (clientToInactive is null)
                throw new NotFoundException(nameof(Client), request.Id);

            //Inactive in database
            await _clientRepository.InactiveAsync(clientToInactive);

            return Unit.Value;
        }
    }
}
