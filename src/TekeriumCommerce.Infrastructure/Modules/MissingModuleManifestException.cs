using System;

namespace TekeriumCommerce.Infrastructure.Modules
{
    public class MissingModuleManifestException : Exception
    {
        public string ModuleName { get; set; }

        public MissingModuleManifestException()
        {
        }

        public MissingModuleManifestException(string message) : base(message)
        {
        }

        public MissingModuleManifestException(string message, string moduleName) : this(message)
        {
            this.ModuleName = moduleName;
        }
    }
}