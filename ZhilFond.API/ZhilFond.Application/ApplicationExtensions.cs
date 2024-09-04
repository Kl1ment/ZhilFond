using Microsoft.Extensions.DependencyInjection;
using ZhilFond.Application.Services;

namespace ZhilFond.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBalanceService, BalanceService>();
            services.AddScoped<ITimeService, TimeService>();
            services.AddScoped<IAccrualService, AccrualService>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}
