using AutoMapper;
using Moq;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Features.Client.Queries.GetClientDetail;
using PrestameSoft.Application.MappingProfiles;
using PrestameSoft.Application.UnitTests.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.UnitTests.Features.Client.Queries
{
    public class GetClientDetailQueryHandlerTest
    {
        private readonly Mock<IClientRepository> _mockRepository;
        private readonly IMapper _mapper;


        public GetClientDetailQueryHandlerTest()
        {
            _mockRepository = MockClientRepository.GetMockClientRepository();

            _mapper = new MapperConfiguration(c => 
            {
                c.AddProfile<ClientProfile>();
            }).CreateMapper();
        }

        [Fact]
        public async Task GetClientDetailsTest()
        {
            var handler = new GetClientDetailsQueryHandler(_mapper, _mockRepository.Object);

            var result = await handler.Handle(new GetClientDetailsQuery(1), CancellationToken.None);

            result.ShouldBeOfType<ClientDetailsDto>();
        }
    }
}
