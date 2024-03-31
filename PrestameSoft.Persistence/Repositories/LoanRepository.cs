using Microsoft.EntityFrameworkCore;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Domain;
using PrestameSoft.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Persistence.Repositories;

public class LoanRepository : GenericRepository<Loan>, ILoanRepository
{
    public LoanRepository(DataContext context) : base(context)
    {
    }

    public async Task<Loan> GetLoanWithDetails(int id)
    {
        var loanWithDetails = await _context.Loans
            .Include(l => l.Client).AsNoTracking()
            .Include(l => l.Payments).AsNoTracking()
            .FirstOrDefaultAsync(l => l.Id == id);

        return loanWithDetails;
    }
}
