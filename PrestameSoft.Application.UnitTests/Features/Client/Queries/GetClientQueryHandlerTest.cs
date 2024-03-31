using AutoMapper;
using Moq;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Features.Client.Queries.GetAllClients;
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
    public class GetClientQueryHandlerTest
    {
        private readonly Mock<IClientRepository> _mockRepository;
        private readonly IMapper _mapper;

        public GetClientQueryHandlerTest()
        {
            _mockRepository = MockClientRepository.GetMockClientRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ClientProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetClientListTest()
        {
            var handler = new GetClientQueryHandler(_mapper, _mockRepository.Object);

            var result = await handler.Handle(new GetClientQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<ClientDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
