using AutoMapper;
using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Client.Queries.GetClientDetail
{
    public class GetClientDetailsQueryHandler : IRequestHandler<GetClientDetailsQuery, ClientDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public GetClientDetailsQueryHandler(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<ClientDetailsDto> Handle(GetClientDetailsQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);

            if (client is null)
                throw new NotFoundException(nameof(Client), request.Id);

            var data = _mapper.Map<ClientDetailsDto>(client);

            return data;
        }
    }
}
