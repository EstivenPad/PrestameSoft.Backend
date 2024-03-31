using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Loan.Commands.UpdateLoan
{
    public class UpdateLoanCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public double Amount { get; set; }
    }
}
