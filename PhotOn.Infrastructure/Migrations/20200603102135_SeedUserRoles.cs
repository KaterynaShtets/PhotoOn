using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotOn.Infrastructure.Migrations
{
    public partial class SeedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'72bf4ad2-1fe6-4ab8-a72e-00b7dc61bfa0', N'1dbecfbd-1cb2-4364-a2c1-f0734e8ec909')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'891b67fd-fca4-461e-b057-eb8aafd336c7', N'4cc0d7db-a3d6-4290-8b63-34df7756a583')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'17c05e72-615d-4375-b89a-f0c82a0fc03d', N'58b4fbe9-035a-4d8d-ae54-22fc55e27fbb')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bb97904f-d17d-4871-9db7-93838592b768', N'58b4fbe9-035a-4d8d-ae54-22fc55e27fbb')
GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
