using AutoMapper;
using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Client.Queries.GetAllClients
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, List<ClientDto>>
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public GetClientQueryHandler(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientDto>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var clients = await _clientRepository.GetAsync();

            //Convert data objects to DTO objects
            var data = _mapper.Map<List<ClientDto>>(clients);

            //Return list DTO objects
            return data;
        }
    }
}
