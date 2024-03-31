using Moq;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.UnitTests.Mocks
{
    public class MockClientRepository
    {
        public static Mock<IClientRepository> GetMockClientRepository() 
        {
            var clients = new List<Client>
            {
                new Client
                {
                    Id = 1,
                    Name = "Test Name 1",
                    LastName = "Test LastName 1",
                    Address = "Test Address 1",
                    Phone = "000-000-0000",
                    Identification = "000-0000000-0"
                },
                new Client
                {
                    Id = 2,
                    Name = "Test Name 2",
                    LastName = "Test LastName 2",
                    Address = "Test Address 2",
                    Phone = "000-000-0000",
                    Identification = "000-0000000-0"
                },
                new Client
                {
                    Id = 3,
                    Name = "Test Name 3",
                    LastName = "Test LastName 3",
                    Address = "Test Address 3",
                    Phone = "000-000-0000",
                    Identification = "000-0000000-0"
                }
            };

            var mockRepository = new Mock<IClientRepository>();

            mockRepository.Setup(r => r.GetAsync()).ReturnsAsync(clients);
            
            mockRepository.Setup(r => r.CreateAsync(It.IsAny<Client>()))
                .Returns((Client client) =>
                {
                    clients.Add(client);
                    return Task.CompletedTask;
                });

            return mockRepository;
        }
    }
}
