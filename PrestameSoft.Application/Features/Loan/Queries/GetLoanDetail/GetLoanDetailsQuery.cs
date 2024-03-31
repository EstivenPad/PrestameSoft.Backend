using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Loan.Queries.GetLoanDetail
{
    public record GetLoanDetailsQuery(int Id) : IRequest<LoanDetailsDto>;
}
