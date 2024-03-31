using AutoMapper;
using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Client.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        
        public CreateClientCommandHandler(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateClientCommandValidator(_clientRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Client", validationResult);

            //Convert to domain entity object
            var clientToCreate = _mapper.Map<Domain.Client>(request);
            
            //Add to database
            await _clientRepository.CreateAsync(clientToCreate);

            //Return Id
            return clientToCreate.Id;
        }
    }
}
