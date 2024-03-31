using PrestameSoft.Application.Features.Client.Queries.GetAllClients;
using PrestameSoft.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Loan.Queries.GetAllLoans
{
    public class LoanDto
    {
        public double Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public int ClientId { get; set; }
    }
}
