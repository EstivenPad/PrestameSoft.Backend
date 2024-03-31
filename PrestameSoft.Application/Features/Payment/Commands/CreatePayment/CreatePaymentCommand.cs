using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Payment.Commands.CreatePayment
{
    public class CreatePaymentCommand : IRequest<int>
    {
        public double CapitalDeposit { get; set; }
        public double InterestDeposit { get; set; }
        public bool Fortnight { get; set; }
        public int LoanId { get; set; }
    }
}
