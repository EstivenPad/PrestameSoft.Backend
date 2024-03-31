using PrestameSoft.Domain;

namespace PrestameSoft.Application.Contracts.Persistence;

public interface IPaymentRepository : IGenericRepository<Payment>
{
    Task<Payment> GetPaymentWithDetails(int paymentId);
    Task<Payment> GetLastPaymentAsync();
}
