using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Core.Data
{
    public class CoreCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppSetting>().ToTable("Core_AppSetting");

            modelBuilder.Entity<User>().ToTable("Core_User");

            modelBuilder.Entity<Role>().ToTable("Core_Role");

            modelBuilder.Entity<IdentityUserClaim<long>>(b =>
            {
                b.HasKey(uc => uc.Id);
                b.ToTable("Core_UserClaim");
            });

            modelBuilder.Entity<IdentityRoleClaim<long>>(b =>
            {
                b.HasKey(rc => rc.Id);
                b.ToTable("Core_RoleClaim");
            });

            modelBuilder.Entity<UserRole>(b =>
            {
                b.HasKey(ur => new {ur.UserId, ur.RoleId});
                b.HasOne(ur => ur.Role).WithMany(x => x.Users).HasForeignKey(r => r.RoleId);
                b.HasOne(ur => ur.User).WithMany(x => x.Roles).HasForeignKey(r => r.UserId);
                b.ToTable("Core_UserRole");
            });

            modelBuilder.Entity<IdentityUserLogin<long>>(b => { b.ToTable("Core_UserLogin"); });

            modelBuilder.Entity<IdentityUserToken<long>>(b => { b.ToTable("Core_UserToken"); });

            modelBuilder.Entity<Entity>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.EntityId);
            });

            // todo: entity builder

            // done! todo: at the end call SeedData method

            CoreSeedData.SeedData(modelBuilder);
        }
    }
}