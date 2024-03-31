using AutoMapper;
using FluentValidation;
using PrestameSoft.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Payment.Commands.UpdatePayment
{
    public class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentCommand>
    {
        private readonly IPaymentRepository _paymentRepository;

        public UpdatePaymentCommandValidator(IPaymentRepository paymentRepository)
        {
            RuleFor(p => p.Id)
                .MustAsync(PaymentMustExist).WithMessage("Payment doesn't exist");

            RuleFor(p => p.CapitalDeposit)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater or equal to {ComparisonValue}");

            RuleFor(p => p.InterestDeposit)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater or equal to {ComparisonValue}");
            
            _paymentRepository = paymentRepository;
        }

        private async Task<bool> PaymentMustExist(int paymentId, CancellationToken token)
        {
            var payment = await _paymentRepository.GetByIdAsync(paymentId);
            return payment != null;
        }
    }
}
