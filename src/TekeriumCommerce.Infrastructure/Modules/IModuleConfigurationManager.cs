using System;
using System.Collections.Generic;
using System.Text;

namespace TekeriumCommerce.Infrastructure.Modules
{
    public interface IModuleConfigurationManager
    {
        IEnumerable<ModuleInfo> GetModules();
    }
}
