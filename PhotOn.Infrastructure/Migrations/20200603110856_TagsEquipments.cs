using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotOn.Infrastructure.Migrations
{
    public partial class TagsEquipments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"SET IDENTITY_INSERT [dbo].[Equipment] ON 

INSERT [dbo].[Equipment] ([Id], [IsDeleted], [Title]) VALUES (2, 0, N'PhotoCamera')
INSERT [dbo].[Equipment] ([Id], [IsDeleted], [Title]) VALUES (3, 0, N'VideoCamera')
INSERT [dbo].[Equipment] ([Id], [IsDeleted], [Title]) VALUES (4, 0, N'GoPro')
SET IDENTITY_INSERT [dbo].[Equipment] OFF
GO
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([Id], [IsDeleted], [Title]) VALUES (1, 0, N'Paris')
INSERT [dbo].[Tags] ([Id], [IsDeleted], [Title]) VALUES (2, 0, N'Kharkiv')
INSERT [dbo].[Tags] ([Id], [IsDeleted], [Title]) VALUES (3, 0, N'London')
INSERT [dbo].[Tags] ([Id], [IsDeleted], [Title]) VALUES (4, 0, N'Kiev')
SET IDENTITY_INSERT [dbo].[Tags] OFF
GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
