using PrestameSoft.Application.Features.Client.Queries.GetAllClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Features.Loan.Queries.GetLoanDetail
{
    public class LoanDetailsDto
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; } = string.Empty;

        public int ClientId { get; set; }
        public ClientDto? Client { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
