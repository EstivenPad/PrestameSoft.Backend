using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Payment.Queries.GetPaymentDetail
{
    public record GetPaymentDetailsQuery(int Id) : IRequest<PaymentDetailsDto>;
}
