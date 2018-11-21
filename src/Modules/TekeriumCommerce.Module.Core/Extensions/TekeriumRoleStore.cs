using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TekeriumCommerce.Module.Core.Data;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Core.Extensions
{
    public class TekeriumRoleStore : RoleStore<Role, TekerDbContext, long, UserRole, IdentityRoleClaim<long>>
    {
        public TekeriumRoleStore(TekerDbContext context) : base(context)
        {
        }
    }
}