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
            
            RuleFor(l => l.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            _clientRepository = clientRepository;
            _loanRepository = loanRepository;
        }

        private async Task<bool> LoanMustNotHavePayments(int loanId, CancellationToken token)
        {
            //validar que no tenga pagos para permitir editarlo
            var loan = await _loanRepository.GetLoanWithDetails(loanId);

            return (loan.Payments?.Count() > 0) == false;
        }
    }
}
