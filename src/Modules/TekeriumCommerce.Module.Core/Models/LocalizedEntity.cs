using System;
using System.Collections.Generic;
using System.Text;

namespace TekeriumCommerce.Module.Core.Models
{
    public interface ILocalizedEntity
    {
        IList<LocalizedProperty> Locales { get; set; }
    }
}