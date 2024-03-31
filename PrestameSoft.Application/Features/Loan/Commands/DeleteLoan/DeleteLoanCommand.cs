using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Loan.Commands.DeleteLoan
{
    public class DeleteLoanCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
