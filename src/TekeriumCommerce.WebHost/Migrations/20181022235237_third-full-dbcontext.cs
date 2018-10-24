using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TekeriumCommerce.WebHost.Migrations
{
    public partial class thirdfulldbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "Core_UserToken");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Core_User");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "Core_UserRole");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "Core_UserLogin");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "Core_UserClaim");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Core_Role");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "Core_RoleClaim");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "Core_UserRole",
                newName: "IX_Core_UserRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "Core_UserLogin",
                newName: "IX_Core_UserLogin_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "Core_UserClaim",
                newName: "IX_Core_UserClaim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "Core_RoleClaim",
                newName: "IX_Core_RoleClaim_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Core_UserToken",
                table: "Core_UserToken",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Core_User",
                table: "Core_User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Core_UserRole",
                table: "Core_UserRole",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Core_UserLogin",
                table: "Core_UserLogin",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Core_UserClaim",
                table: "Core_UserClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Core_Role",
                table: "Core_Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Core_RoleClaim",
                table: "Core_RoleClaim",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Core_AppSetting",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Module = table.Column<string>(nullable: true),
                    IsVisibleInCommonSettingPage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_AppSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Content",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Slug = table.Column<string>(maxLength: 450, nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    PublishedOn = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Content", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_Content_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_Content_Core_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Core_EntityType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsMenuable = table.Column<bool>(nullable: false),
                    AreaName = table.Column<string>(maxLength: 450, nullable: true),
                    RoutingController = table.Column<string>(maxLength: 450, nullable: true),
                    RoutingAction = table.Column<string>(maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_EntityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Media",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Caption = table.Column<string>(nullable: true),
                    FileSize = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    MediaType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Entity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Slug = table.Column<string>(maxLength: 450, nullable: false),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    EntityId = table.Column<long>(nullable: false),
                    EntityTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_Entity_Core_EntityType_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "Core_EntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Core_AppSetting",
                columns: new[] { "Id", "IsVisibleInCommonSettingPage", "Module", "Value" },
                values: new object[,]
                {
                    { "Global.AssetVersion", true, "Core", "1.0" },
                    { "Theme", false, "Core", "Generic" }
                });

            migrationBuilder.InsertData(
                table: "Core_Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1L, "", "admin", "ADMIN" },
                    { 3L, "", "guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "Core_User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Culture", "Email", "EmailConfirmed", "FullName", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshTokenHash", "SecurityStamp", "TwoFactorEnabled", "UpdatedOn", "UserGuid", "UserName", "VendorId" },
                values: new object[] { 10L, 0, "c83afcbc-312c-4589-bad7-8686bd4754c0", new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 190, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), null, "admin@simplcommerce.com", false, "Shop Admin", false, false, null, "ADMIN@SIMPLCOMMERCE.COM", "ADMIN@SIMPLCOMMERCE.COM", "AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==", null, false, null, "d6847450-47f0-4c7a-9fed-0c66234bf61f", false, new DateTimeOffset(new DateTime(2018, 5, 29, 4, 33, 39, 190, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("ed8210c3-24b0-4823-a744-80078cf12eb4"), "admin@simplcommerce.com", null });

            migrationBuilder.InsertData(
                table: "Core_UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 10L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Core_Content_CreatedById",
                table: "Core_Content",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Content_UpdatedById",
                table: "Core_Content",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Entity_EntityTypeId",
                table: "Core_Entity",
                column: "EntityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Core_RoleClaim_Core_Role_RoleId",
                table: "Core_RoleClaim",
                column: "RoleId",
                principalTable: "Core_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserClaim_Core_User_UserId",
                table: "Core_UserClaim",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserLogin_Core_User_UserId",
                table: "Core_UserLogin",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserRole_Core_Role_RoleId",
                table: "Core_UserRole",
                column: "RoleId",
                principalTable: "Core_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserRole_Core_User_UserId",
                table: "Core_UserRole",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserToken_Core_User_UserId",
                table: "Core_UserToken",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Core_RoleClaim_Core_Role_RoleId",
                table: "Core_RoleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserClaim_Core_User_UserId",
                table: "Core_UserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserLogin_Core_User_UserId",
                table: "Core_UserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserRole_Core_Role_RoleId",
                table: "Core_UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserRole_Core_User_UserId",
                table: "Core_UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserToken_Core_User_UserId",
                table: "Core_UserToken");

            migrationBuilder.DropTable(
                name: "Core_AppSetting");

            migrationBuilder.DropTable(
                name: "Core_Content");

            migrationBuilder.DropTable(
                name: "Core_Entity");

            migrationBuilder.DropTable(
                name: "Core_Media");

            migrationBuilder.DropTable(
                name: "Core_EntityType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Core_UserToken",
                table: "Core_UserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Core_UserRole",
                table: "Core_UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Core_UserLogin",
                table: "Core_UserLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Core_UserClaim",
                table: "Core_UserClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Core_User",
                table: "Core_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Core_RoleClaim",
                table: "Core_RoleClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Core_Role",
                table: "Core_Role");

            migrationBuilder.DeleteData(
                table: "Core_Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { 3L, "" });

            migrationBuilder.DeleteData(
                table: "Core_UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 10L, 1L });

            migrationBuilder.DeleteData(
                table: "Core_Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { 1L, "" });

            migrationBuilder.DeleteData(
                table: "Core_User",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { 10L, "c83afcbc-312c-4589-bad7-8686bd4754c0" });

            migrationBuilder.RenameTable(
                name: "Core_UserToken",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "Core_UserRole",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "Core_UserLogin",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "Core_UserClaim",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "Core_User",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Core_RoleClaim",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "Core_Role",
                newName: "AspNetRoles");

            migrationBuilder.RenameIndex(
                name: "IX_Core_UserRole_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Core_UserLogin_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Core_UserClaim_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Core_RoleClaim_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddColumn<long>(
                name: "RoleId1",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
