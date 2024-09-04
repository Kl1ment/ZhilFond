using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZhilFond.DataAccess.Entities;

namespace ZhilFond.DataAccess.Configurations
{
    public class AccrualConfiguration : IEntityTypeConfiguration<AccrualEntity>
    {
        public void Configure(EntityTypeBuilder<AccrualEntity> builder)
        {
            builder.HasKey(a => a.Id);
        }
    }
}
