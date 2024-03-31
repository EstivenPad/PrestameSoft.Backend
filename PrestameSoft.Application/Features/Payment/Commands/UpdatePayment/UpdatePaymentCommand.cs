using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Payment.Commands.UpdatePayment
{
    public class UpdatePaymentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public double CapitalDeposit { get; set; }
        public double InterestDeposit { get; set; }
        public bool Fortnight { get; set; }
    }
}
