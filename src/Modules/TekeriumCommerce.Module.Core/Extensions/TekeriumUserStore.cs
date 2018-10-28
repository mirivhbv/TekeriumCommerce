using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TekeriumCommerce.Module.Core.Data;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Core.Extensions
{
    public class TekeriumUserStore : UserStore<User, Role, TekerDbContext, long, IdentityUserClaim<long>, UserRole,
        IdentityUserLogin<long>, IdentityUserToken<long>, IdentityRoleClaim<long>>
    {
        public TekeriumUserStore(TekerDbContext context, IdentityErrorDescriber describer) : base(context, describer)
        {
        }
    }
}