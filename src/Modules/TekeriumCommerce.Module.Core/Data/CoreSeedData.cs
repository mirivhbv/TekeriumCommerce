using System;
using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Core.Data
{
    public static class CoreSeedData
    {
        public static void SeedData(ModelBuilder builder)
        {
            builder.Entity<AppSetting>().HasData(
                new AppSetting("Global.AssetVersion") { Module = "Core", IsVisibleInCommonSettingPage = true, Value = "1.0" },
                new AppSetting("Theme") { Module = "Core", IsVisibleInCommonSettingPage = false, Value = "Generic" }
            );

            builder.Entity<Role>().HasData(
                new Role { Id = 1L, ConcurrencyStamp = "4776a1b2-dbe4-4056-82ec-8bed211d1454", Name = "admin", NormalizedName = "ADMIN" },
                new Role { Id = 3L, ConcurrencyStamp = "d4754388-8355-4018-b728-218018836817", Name = "guest", NormalizedName = "GUEST" }
            );

            builder.Entity<User>().HasData(
                new User { Id = 10L, AccessFailedCount = 0, ConcurrencyStamp = "c83afcbc-312c-4589-bad7-8686bd4754c0", CreatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 190, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), Email = "admin@simplcommerce.com", EmailConfirmed = false, FullName = "Shop Admin", IsDeleted = false, LockoutEnabled = false, NormalizedEmail = "ADMIN@SIMPLCOMMERCE.COM", NormalizedUserName = "ADMIN@SIMPLCOMMERCE.COM", PasswordHash = "AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==", PhoneNumberConfirmed = false, SecurityStamp = "d6847450-47f0-4c7a-9fed-0c66234bf61f", TwoFactorEnabled = false, UpdatedOn = new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 190, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), UserGuid = new Guid("ed8210c3-24b0-4823-a744-80078cf12eb4"), UserName = "admin@simplcommerce.com" }
            );

            builder.Entity<UserRole>().HasData(new UserRole { UserId = 10, RoleId = 1 });
        }
    }
}