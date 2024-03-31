using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Loan.Commands.CreateLoan
{
    public class CreateLoanCommand : IRequest<int>
    {
        public double Amount { get; set; }
        public int ClientId { get; set; }
    }
}
