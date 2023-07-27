using Case.Application.Services;
using Case.Persistance.Config;
using Case.Persistance.Context;
using Case.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Case.Persistance;

 public static class ServiceRegistration
    {
        
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContextPool<KafeinCaseDataContext>(options => 
                options.UseSqlServer(BaseConfiguration.ConnectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<IUserService, UserService>();
  
        }
    }