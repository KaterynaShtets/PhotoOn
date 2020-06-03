using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotOn.Infrastructure.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DOB], [Balance]) VALUES (N'17c05e72-615d-4375-b89a-f0c82a0fc03d', N'photon.user@gmail.com', N'PHOTON.USER@GMAIL.COM', N'photon.user@gmail.com', N'PHOTON.USER@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKA7vN+9SrQWFSSNks6lr68ezpm7ogpF26rja/JpfDqZ4BKJgSfIvu2pvuBRWZp76A==', N'UD6X7CJXVINF4VBIOIVI3Z46PQQCFUQC', N'1bb03afd-8207-4198-b966-71c8ae8cb45b', NULL, 0, 0, NULL, 1, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DOB], [Balance]) VALUES (N'72bf4ad2-1fe6-4ab8-a72e-00b7dc61bfa0', N'photon.exp@gmail.com', N'PHOTON.EXP@GMAIL.COM', N'photon.exp@gmail.com', N'PHOTON.EXP@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAENn7H7o2fWQqqiA/RzvJbeGO0j3ONdW/YkwwUYFMqS5WNm07xk7dfg72Mr6+xjY2jQ==', N'URKUPQ2ZZWIP2I2F6Y3ZN2JZ5UIQK3C4', N'b1be60fe-abf3-4c54-a696-cc4482994a99', NULL, 0, 0, NULL, 1, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DOB], [Balance]) VALUES (N'891b67fd-fca4-461e-b057-eb8aafd336c7', N'photon.adm@gmail.com', N'PHOTON.ADM@GMAIL.COM', N'photon.adm@gmail.com', N'PHOTON.ADM@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAECswUsbEm87NizUjk8iPYS4e4ASYskiA1/YYecoRPQL5nUBtGMjiOCHCAeux57Bgtg==', N'iuyiyiuyiyu', N'yuijyiu', NULL, 0, 0, NULL, 1, 0, CAST(N'1985-06-12T00:00:00.0000000' AS DateTime2), 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DOB], [Balance]) VALUES (N'bb97904f-d17d-4871-9db7-93838592b768', N'katetkacenko@gmail.com', N'KATETKACENKO@GMAIL.COM', N'katetkacenko@gmail.com', N'KATETKACENKO@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEL/iTqR3uZWVx6LRcWS8xc0x1SYgXAz68BBoLSI6/mZOIvtAbmI30UI3+E2cWuxjxw==', N'JDRVOHOZAT3CW3BETBVVZIEHUHIBYMBL', N'9d45061a-c9af-4419-a485-ecaf68e54563', NULL, 0, 0, NULL, 1, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0)
GO

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
