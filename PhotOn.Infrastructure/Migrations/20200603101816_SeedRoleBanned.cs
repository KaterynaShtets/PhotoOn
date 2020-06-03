using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotOn.Infrastructure.Migrations
{
    public partial class SeedRoleBanned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'aaaecfbd-1cb2-4364-a2c1-f0734e8ec909', N'Banned', N'Banned', NULL) 
                                   GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
