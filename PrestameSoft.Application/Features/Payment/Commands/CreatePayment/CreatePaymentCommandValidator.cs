using FluentValidation;
using PrestameSoft.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Payment.Commands.CreatePayment
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IPaymentRepository _paymentRepository;

        public CreatePaymentCommandValidator(ILoanRepository loanRepository, IPaymentRepository paymentRepository)
        {
            RuleFor(p => p.CapitalDeposit)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater or equal to {ComparisonValue}");

            RuleFor(p => p.InterestDeposit)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater or equal to {ComparisonValue}");

            RuleFor(p => p.LoanId)
                .MustAsync(LoanMustExist).WithMessage("Loan doesn't exist");

            RuleFor(p => p.Fortnight)
                .MustAsync(FortnightMustBeDifferentFromLast).WithMessage("A payment already exist for that fortnight");

            _loanRepository = loanRepository;
            _paymentRepository = paymentRepository;
        }

        private async Task<bool> FortnightMustBeDifferentFromLast(bool fortnight, CancellationToken token)
        {
            var lastPayment = await _paymentRepository.GetLastPaymentAsync();
            return lastPayment.Fortnight != fortnight;
        }

        private async Task<bool> LoanMustExist(int loanId, CancellationToken token)
        {
            var loan = await _loanRepository.GetByIdAsync(loanId);
            return loan != null;
        }
    }
}
