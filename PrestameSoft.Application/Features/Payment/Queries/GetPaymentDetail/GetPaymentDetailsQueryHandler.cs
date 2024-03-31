using AutoMapper;
using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Payment.Queries.GetPaymentDetail
{
    public class GetPaymentDetailsQueryHandler : IRequestHandler<GetPaymentDetailsQuery, PaymentDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentDetailsQueryHandler(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }
        public async Task<PaymentDetailsDto> Handle(GetPaymentDetailsQuery request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetByIdAsync(request.Id);

            if (payment is null)
                throw new NotFoundException(nameof(Payment), request.Id);

            var data = _mapper.Map<PaymentDetailsDto>(payment);

            return data;
        }
    }
}
