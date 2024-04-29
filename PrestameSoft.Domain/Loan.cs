using PrestameSoft.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Domain;

public class Loan : BaseEntity
{
    public enum LoanStatus
    {
        Inactivo,
        Activo
    }

    public double Amount { get; set; }
    public double CapitalRemaining { get; set; }
    public LoanStatus Status { get; set; } = LoanStatus.Activo;

    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public List<Payment>? Payments { get; set; }
}
