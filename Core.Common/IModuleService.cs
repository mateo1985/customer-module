namespace Core.Common
{
    using System.Collections.Generic;

    public interface IModuleService
    {
        IDictionary<string, IModule> Modules { get; }
    }
}
