using PrestameSoft.Domain;

namespace PrestameSoft.Application.Contracts.Persistence
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<bool> IsClientUnique(string name);
    }
}
