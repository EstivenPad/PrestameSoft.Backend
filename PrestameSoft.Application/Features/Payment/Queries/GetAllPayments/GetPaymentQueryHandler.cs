using AutoMapper;
using MediatR;
using PrestameSoft.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Payment.Queries.GetAllPayments
{
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, List<PaymentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentQueryHandler(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<List<PaymentDto>> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var payments = await _paymentRepository.GetAsync();

            //Converto data objects to DTO objects
            var data = _mapper.Map<List<PaymentDto>>(payments);

            //Return list DTO objects
            return data;
        }
    }
}
