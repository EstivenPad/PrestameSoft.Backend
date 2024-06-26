﻿using PrestameSoft.Domain;

namespace PrestameSoft.Application.Contracts.Persistence
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        Task<Loan> GetLoanWithDetails(int loanId);
        Task<bool> LoanHasAnyPayment(int loanId);
        Task ChangeLoanStatus(int loanId);
    }
}
