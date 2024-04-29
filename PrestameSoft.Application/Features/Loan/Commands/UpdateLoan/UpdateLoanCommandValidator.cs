using FluentValidation;
using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Loan.Commands.UpdateLoan
{
    public class UpdateLoanCommandValidator : AbstractValidator<UpdateLoanCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILoanRepository _loanRepository;

        public UpdateLoanCommandValidator(IClientRepository clientRepository, ILoanRepository loanRepository)
        {
            RuleFor(l => l.Id)
                .MustAsync(LoanMustNotHavePayments).WithMessage("Loan can't be modified because already has an assigned payment");

            RuleFor(l => l.Id)
                .MustAsync(LoanMustBeActive).WithMessage("Loan is Inactive");

            RuleFor(l => l.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            _clientRepository = clientRepository;
            _loanRepository = loanRepository;
        }

        private async Task<bool> LoanMustNotHavePayments(int loanId, CancellationToken token)
        {
            //Check that the loan doesn't have any payments assigned; let it be updated.
            return await _loanRepository.LoanHasAnyPayment(loanId);
        }

        private async Task<bool> LoanMustBeActive(int loandId, CancellationToken token)
        {
            var loan = await _loanRepository.GetByIdAsync(loandId);

            return (loan.Status == Domain.Loan.LoanStatus.Activo);
        }
    }
}
