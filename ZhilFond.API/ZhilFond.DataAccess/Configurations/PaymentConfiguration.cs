using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZhilFond.DataAccess.Entities;

namespace ZhilFond.DataAccess.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
