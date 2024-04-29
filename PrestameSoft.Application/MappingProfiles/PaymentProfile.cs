using AutoMapper;
using PrestameSoft.Application.Features.Payment.Commands.CreatePayment;
using PrestameSoft.Application.Features.Payment.Queries.GetAllPayments;
using PrestameSoft.Application.Features.Payment.Queries.GetPaymentDetail;
using PrestameSoft.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.MappingProfiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentDto, Payment>().ReverseMap();
            CreateMap<Payment, PaymentDetailsDto>();
            CreateMap<CreatePaymentCommand, Payment>();
        }
    }
}
