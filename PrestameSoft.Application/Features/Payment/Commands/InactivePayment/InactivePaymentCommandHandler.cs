using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Payment.Commands.InactivePayment
{
    public class InactivePaymentCommandHandler : IRequestHandler<InactivePaymentCommand, Unit>
    {
        private readonly IPaymentRepository _paymentRepository;

        public InactivePaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Unit> Handle(InactivePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentToDelete = await _paymentRepository.GetByIdAsync(request.Id);

            if (paymentToDelete is null)
                throw new NotFoundException(nameof(Payment), request.Id);

            await _paymentRepository.InactiveAsync(paymentToDelete);

            return Unit.Value;
        }
    }
}
