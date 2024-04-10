using Microsoft.EntityFrameworkCore;
using PrestameSoft.Application.Constants;
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

    public override async Task CreateAsync(Payment payment)
    {
        //Modification of the Capital Remaining over the payment's loan 
        
        var loan = await _context.Loans.FirstOrDefaultAsync(l => l.Id == payment.LoanId);
        
        var loanInterest = Math.Round((loan.CapitalRemaining * Percentages.InterestRate), 2);

        if (payment.InterestDeposit < loanInterest)
            loan.CapitalRemaining += (loanInterest - payment.InterestDeposit);

        loan.CapitalRemaining -= payment.CapitalDeposit;

        await _context.AddAsync(payment);
        await _context.SaveChangesAsync();
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
