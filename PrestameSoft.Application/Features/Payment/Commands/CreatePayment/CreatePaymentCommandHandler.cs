using AutoMapper;
using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Payment.Commands.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;
        private readonly ILoanRepository _loanRepository;

        public CreatePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository, ILoanRepository loanRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _loanRepository = loanRepository;
        }
        public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePaymentCommandValidator(_loanRepository, _paymentRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Payment", validationResult);

            var paymentToCreate = _mapper.Map<Domain.Payment>(request);

            paymentToCreate.PaidDate = DateTime.Now;

            await _paymentRepository.CreateAsync(paymentToCreate);

            return paymentToCreate.Id;
        }

    }
}
