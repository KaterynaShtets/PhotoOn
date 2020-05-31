using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotOn.Infrastructure.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                Insert into AspNetRoles(Id, [name], [NormalizedName])
                values('4cc0d7db-a3d6-4290-8b63-34df7756a583', 'Admin', 'Admin')
            ");
            migrationBuilder.Sql(@"
                Insert into AspNetRoles(Id, [name], [NormalizedName])
                values('1dbecfbd-1cb2-4364-a2c1-f0734e8ec909', 'Expert', 'Expert')
            ");
            migrationBuilder.Sql(@"
                Insert into AspNetRoles(Id, [name], [NormalizedName])
                values('58b4fbe9-035a-4d8d-ae54-22fc55e27fbb', 'User', 'User')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                delete AspNetRoles where id ='4cc0d7db-a3d6-4290-8b63-34df7756a583'
            ");
            migrationBuilder.Sql(@"
                delete AspNetRoles where id ='1dbecfbd-1cb2-4364-a2c1-f0734e8ec909'
            ");
            migrationBuilder.Sql(@"
                delete AspNetRoles where id ='58b4fbe9-035a-4d8d-ae54-22fc55e27fbb'
            ");
        }
    }
}
