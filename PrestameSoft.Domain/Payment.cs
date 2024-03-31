using PrestameSoft.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Domain;

public class Payment : BaseEntity
{
    public double CapitalDeposit { get; set; }
    public double InterestDeposit { get; set; }
    public bool Fortnight { get; set; }
    public DateTime PaidDate { get; set; }

    public int LoanId { get; set; }
    public Loan? Loan { get; set; }
}
