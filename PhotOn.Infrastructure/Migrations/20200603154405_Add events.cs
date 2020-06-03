using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotOn.Infrastructure.Migrations
{
    public partial class Addevents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([Id], [IsDeleted], [DateTime], [TextDescription], [AwardTitle], [TagId], [ImageLink]) VALUES (243, 0, CAST(N'2020-06-15T00:00:00.0000000' AS DateTime2), N'Take a photo near Big Ban', N'Big Ban Friend', 3, N'https://photonproject.blob.core.windows.net/events/event3.jpg')
INSERT [dbo].[Events] ([Id], [IsDeleted], [DateTime], [TextDescription], [AwardTitle], [TagId], [ImageLink]) VALUES (246, 0, CAST(N'2020-06-10T00:00:00.0000000' AS DateTime2), N'Take a photo near Eifel Tower', N' Eye to eye with Eilfel Tower ', 1, N'https://photonproject.blob.core.windows.net/events/event1.jpg')
SET IDENTITY_INSERT [dbo].[Events] OFF
GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
