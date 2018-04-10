namespace Core.Common
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// All modules have to implemen this interface
    /// </summary>
    public interface IModule
    {
        void ProvideServices(IServiceCollection serviceCollection, IConfiguration configuration);

        bool HasControllers { get; }

        string ModuleName { get; }
    }
}
