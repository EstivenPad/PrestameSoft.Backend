using FluentValidation;
using PrestameSoft.Application.Constants;
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
            RuleFor(p => p.LoanId)
                .MustAsync(LoanMustExist).WithMessage("Loan doesn't exist");

            RuleFor(p => p.Fortnight)
                .MustAsync(FortnightMustBeDifferentFromLast).WithMessage("The last payment was created for that fortnight");

            RuleFor(p => p.CapitalDeposit)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater or equal to {ComparisonValue}");

            RuleFor(p => p.InterestDeposit)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater or equal to {ComparisonValue}")
                .MustAsync(InterestDepositGreaterThanLoanInterest).WithMessage("Interest deposit can't be greater than loan's interest");

            _loanRepository = loanRepository;
            _paymentRepository = paymentRepository;
        }

        private async Task<bool> InterestDepositGreaterThanLoanInterest(CreatePaymentCommand payment, double interestDeposit, CancellationToken token)
        {
            var loan = await _loanRepository.GetByIdAsync(payment.LoanId);

            if(loan is null)
                return true;

            return interestDeposit >= Math.Round(loan.CapitalRemaining * Percentages.InterestRate, 2);
        }

        private async Task<bool> FortnightMustBeDifferentFromLast(CreatePaymentCommand payment, bool fortnight, CancellationToken token)
        {
            var lastPayment = await _paymentRepository.GetLastPaymentAsync(payment.LoanId);

            if (lastPayment is null)
                return true;

            return lastPayment.Fortnight != fortnight;
        }

        private async Task<bool> LoanMustExist(int loanId, CancellationToken token)
        {
            var loan = await _loanRepository.GetByIdAsync(loanId);
            return loan != null;
        }
    }
}
