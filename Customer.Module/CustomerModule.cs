namespace Customer.Module
{
    using Core.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Customer.Module.Common;

    [Module]
    public class CustomerModule: IModule
    {
        private const string ConnectionString = "ConnectionStrings:SimpleModularApplicationConnection";

        public void ProvideServices(IServiceCollection serviceCollection,
                                    IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(ICustomerService), typeof(SqlCustomerData));
            serviceCollection.AddDbContext<CustomerDbContext>(options => options.UseSqlServer(configuration[ConnectionString]));
            serviceCollection.AddScoped<ICustomerDbContext, CustomerDbContext>();
        }

        public bool HasControllers => true;

        public string ModuleName => "Customer";
        
    }
}
