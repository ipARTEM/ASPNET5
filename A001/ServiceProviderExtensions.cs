
using Microsoft.Extensions.DependencyInjection;

namespace A001
{
    public static class ServiceProviderExtensions
    {
        public static void AddTimeService(this IServiceCollection services)
        {
            services.AddTransient<TimeService>();         // расширения для интерфейса IServiceCollection.
        }
    }
}
