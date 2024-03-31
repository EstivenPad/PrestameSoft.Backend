using AutoMapper;
using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Client.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public UpdateClientCommandHandler(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new UpdateClientCommandValidator(_clientRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Client");

            //Convert to domain entity object
            var clientToUpdate = await _clientRepository.GetByIdAsync(request.Id);
                
            _mapper.Map(request, clientToUpdate);

            //Update in database
            await _clientRepository.UpdateAsync(clientToUpdate);

            //Return Unit
            return Unit.Value;
        }
    }
}
