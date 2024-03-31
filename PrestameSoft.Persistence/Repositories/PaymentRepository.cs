using Microsoft.EntityFrameworkCore;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using PrestameSoft.Domain;
using PrestameSoft.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Persistence.Repositories;

public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(DataContext context) : base(context)
    {
    }

    public async Task<Payment> GetLastPaymentAsync()
    {
        var lastPayment = await _context.Payments
            .OrderBy(p => p.DateCreated)
            .LastOrDefaultAsync();

        return lastPayment;
    }

    public async Task<Payment> GetPaymentWithDetails(int paymentId)
    {
        var paymentWithDetails = await _context.Payments
            .Include(p => p.Loan).AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == paymentId);

        return paymentWithDetails;
    }
}
