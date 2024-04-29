using Microsoft.EntityFrameworkCore;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Domain;
using PrestameSoft.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Persistence.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsClientUnique(string identification)
        {
            return await _context.Clients.AnyAsync(c => (c.Identification == identification)) == false;
        }

        public async Task<bool> ClientHasAnyLoan(int clientId)
        {
            return await _context.Loans.AnyAsync(c => (c.ClientId == clientId)) == true;
        }
    }
}
