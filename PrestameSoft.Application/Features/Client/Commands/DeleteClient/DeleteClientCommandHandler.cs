using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Client.Commands.DeleteClient
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Unit>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            //Retrieve domain entity object
            var clientToDelete = await _clientRepository.GetByIdAsync(request.Id);

            //Verify that record exist
            if (clientToDelete is null)
                throw new NotFoundException(nameof(Client), request.Id);

            bool clientHasAnyLoan = await _clientRepository.ClientHasAnyLoan(request.Id);

            if (clientHasAnyLoan)
                throw new BadRequestException("Client can't be deleted, because has a Loan assigned");

            //Delete in database
            await _clientRepository.DeleteAsync(clientToDelete);

            return Unit.Value;
        }
    }
}
