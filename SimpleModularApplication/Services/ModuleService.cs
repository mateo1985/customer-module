namespace SimpleModularApplication.Services
{
    using System.Collections.Generic;
    using Core.Common;

    /// <summary>
    /// Service for modules management
    /// </summary>
    public class ModuleService: IModuleService
    {
        private IDictionary<string, IModule> modules;

        /// <summary>
        /// Initializes new instance of ModuleService
        /// </summary>
        /// <param name="modules"></param>
        public ModuleService(IDictionary<string, IModule> modules)
        {
            this.modules = modules;
        }

        /// <summary>
        /// Modules in application
        /// </summary>
        public IDictionary<string, IModule> Modules
        {
            get { return this.modules; }
        }
    }
}
