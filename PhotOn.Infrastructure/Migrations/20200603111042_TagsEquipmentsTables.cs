using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotOn.Infrastructure.Migrations
{
    public partial class TagsEquipmentsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT [dbo].[PublicationEquipments] ([PublicationId], [EquipmentId]) VALUES (1, 2)
INSERT [dbo].[PublicationEquipments] ([PublicationId], [EquipmentId]) VALUES (4, 2)
INSERT [dbo].[PublicationEquipments] ([PublicationId], [EquipmentId]) VALUES (2, 3)
INSERT [dbo].[PublicationEquipments] ([PublicationId], [EquipmentId]) VALUES (3, 4)
GO
INSERT [dbo].[PublicationTags] ([PublicationId], [TagId]) VALUES (1, 1)
INSERT [dbo].[PublicationTags] ([PublicationId], [TagId]) VALUES (3, 2)
INSERT [dbo].[PublicationTags] ([PublicationId], [TagId]) VALUES (2, 3)
INSERT [dbo].[PublicationTags] ([PublicationId], [TagId]) VALUES (4, 4)

GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
