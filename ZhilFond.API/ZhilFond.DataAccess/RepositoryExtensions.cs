using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZhilFond.DataAccess.Repositories;

namespace ZhilFond.DataAccess
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ZhilFondDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(ZhilFondDbContext)));
            });

            services.AddScoped<IBalanceRepository, BalanceRepository>();
            services.AddScoped<IAccrualRepository, AccrualRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IDapperDbContext, DapperDbContext>();

            return services;
        }
    }
}
