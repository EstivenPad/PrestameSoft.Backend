using Microsoft.EntityFrameworkCore;
using PrestameSoft.Domain;
using PrestameSoft.Domain.Common;

namespace PrestameSoft.Persistence.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.IsDeleted = false;
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
