using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PrestameSoft.Domain;
using PrestameSoft.Persistence.DatabaseContext;
using Shouldly;

namespace PrestameSoft.Persistance.IntegrationTests
{
    public class DataContextTest
    {
        private readonly DataContext _dataContext;

        public DataContextTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase<DataContext>(Guid.NewGuid().ToString()).Options;

            _dataContext = new DataContext(options);
        }

        [Fact]
        public async void Save_SetDateCreated()
        {
            var client = new Client
            {
                Id = 1,
                Name = "Test Name 1",
                LastName = "Test LastName 1",
                Address = "Test Address 1",
                Phone = "000-000-0000",
                Identification = "000-0000000-0"
            };

            await _dataContext.Clients.AddAsync(client);
            await _dataContext.SaveChangesAsync();

            client.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModified()
        {
            var client = new Client
            {
                Id = 1,
                Name = "Test Name 1",
                LastName = "Test LastName 1",
                Address = "Test Address 1",
                Phone = "000-000-0000",
                Identification = "000-0000000-0"
            };

            await _dataContext.Clients.AddAsync(client);
            await _dataContext.SaveChangesAsync();

            client.DateModified.ShouldNotBeNull();
        }
    }
}