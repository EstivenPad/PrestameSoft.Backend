using AutoMapper;
using FluentValidation;
using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Payment.Commands.UpdatePayment
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public UpdatePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }
        public async Task<Unit> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePaymentCommandValidator(_paymentRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Payment", validationResult);

            var paymentToUpdate = await _paymentRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, paymentToUpdate);

            await _paymentRepository.UpdateAsync(paymentToUpdate);

            return Unit.Value;
        }
    }
}
