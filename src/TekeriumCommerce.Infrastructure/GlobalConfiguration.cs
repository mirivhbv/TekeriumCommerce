using System;
using System.Collections.Generic;
using TekeriumCommerce.Infrastructure.Localization;
using TekeriumCommerce.Infrastructure.Modules;

namespace TekeriumCommerce.Infrastructure
{
    public static class GlobalConfiguration
    {
        // done! todo: after added ModuleInfo class, remove down comment
        public static IList<ModuleInfo> Modules { get; set; } = new List<ModuleInfo>();

        // done! todo: after adding Culture class, remove comment on down
        public static  IList<Culture> Cultures { get; set; } = new List<Culture>();

        // todo: it's going to be "az-AZ" in further
        public static string DefaultCulture => "en-US";

        public static string WebRootPath { get; set; }

        public static string ContentRootPath { get; set; }
    }
}