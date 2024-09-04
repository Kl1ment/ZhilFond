using Microsoft.EntityFrameworkCore;
using ZhilFond.DataAccess.Configurations;
using ZhilFond.DataAccess.Entities;

namespace ZhilFond.DataAccess
{
    public class ZhilFondDbContext : DbContext
    {
        public ZhilFondDbContext(DbContextOptions<ZhilFondDbContext> options) 
            : base(options) { }

        public DbSet<PaymentEntity> Payments { get; set; }
        public DbSet<AccrualEntity> Accruals { get; set; }


        public void OnModelCrating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccrualConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        }
    }
}
