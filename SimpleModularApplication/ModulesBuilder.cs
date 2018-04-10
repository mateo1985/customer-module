namespace SimpleModularApplication
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Core.Common;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Builds and configures modules for the application
    /// </summary>
    public class ModulesBuilder
    {
        private IMvcBuilder builder;
        private IServiceCollection services;
        private IHostingEnvironment env;
        private IConfiguration configuration;

        public ModulesBuilder(IMvcBuilder builder,
            IServiceCollection services,
            IHostingEnvironment env,
            IConfiguration configuration)
        {
            this.builder = builder;
            this.services = services;
            this.env = env;
            this.configuration = configuration;
        }

        /// <summary>
        /// Build and configure modules
        /// </summary>
        /// <returns>Returns modules for application</returns>
        public IDictionary<string, IModule> LoadModules()
        {
            IDictionary<string, IModule> modules = new Dictionary<string, IModule>();
            const string ModulesPath = "Modules";
            const string ModuleSearchPattern = "*Module.dll";
            var moduleRootFolder = new DirectoryInfo(Path.Combine(env.ContentRootPath, ModulesPath));
            foreach (var moduleFolder in Directory.EnumerateDirectories(moduleRootFolder.FullName))
            {
                foreach (var moduleFile in Directory.EnumerateFiles(moduleFolder, ModuleSearchPattern, SearchOption.AllDirectories))
                {
                    var loadedModules = this.GetModules(moduleFile);
                    if (loadedModules == null)
                    {
                        continue;
                    }

                    foreach (var module in loadedModules)
                    {
                        var createdModule = Activator.CreateInstance(module.Value) as IModule;
                        if (createdModule == null)
                        {
                            continue;
                        }

                        createdModule.ProvideServices(services, this.configuration);
                        modules.Add(moduleFolder, createdModule);
                        if (createdModule.HasControllers)
                        {
                            builder.AddApplicationPart(module.Key).AddControllersAsServices();
                        }
                    }

                }
            }
            
            return modules;
        }

        private IDictionary<Assembly, Type> GetModules(string filePath)
        {
            var dllFile = Assembly.LoadFile(filePath);
            var allTypes = dllFile.GetExportedTypes();
            return allTypes.Where(x =>
            {
                var moduleAttributes = x.GetCustomAttributes(typeof(ModuleAttribute));
                return moduleAttributes != null && moduleAttributes.Any();
            }).ToDictionary(x => dllFile, y => y);
        }
    }
}
