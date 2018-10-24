using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TekeriumCommerce.Infrastructure.Models;

namespace TekeriumCommerce.Module.Core.Models
{
    public class Role : IdentityRole<long>, IEntityWithTypedId<long>
    {
        public IList<UserRole> Users { get; set; } = new List<UserRole>();
    }
}