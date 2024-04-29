using AutoMapper;
using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Payment.Commands.DeletePayment
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, Unit>
    {
        private readonly IPaymentRepository _paymentRepository;

        public DeletePaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Unit> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentToDelete = await _paymentRepository.GetByIdAsync(request.Id);

            if (paymentToDelete is null)
                throw new NotFoundException(nameof(Payment), request.Id);

            var lastPayment = await _paymentRepository.GetLastPaymentAsync(paymentToDelete.LoanId);

            if (paymentToDelete.Id != lastPayment.Id)
                throw new BadRequestException("Only can delete the last payment");

            await _paymentRepository.DeleteAsync(paymentToDelete);

            return Unit.Value;
        }
    }
}
