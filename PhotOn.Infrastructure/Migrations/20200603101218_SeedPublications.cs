using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotOn.Infrastructure.Migrations
{
    public partial class SeedPublications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"SET IDENTITY_INSERT [dbo].[Publications] ON 

INSERT [dbo].[Publications] ([Id], [IsDeleted], [Title], [Price], [coordX], [coordY],  [PublicationDate], [Season], [TextDescription], [LikeCount], [IsApproved], [UserId], [ImageLink]) VALUES (1, 0, N'Paris', 200, CAST(48.86 AS Decimal(18, 2)), CAST(2.29 AS Decimal(18, 2)),  CAST(N'2020-06-02T00:00:00.0000000' AS DateTime2), 2, N'Known as the most visited tourist attraction in Europe, the Eiffel Tower is considered one of the most recognizable and favorite landmarks of the modern world. The symbol of Paris and the whole of France, the Eiffel Tower is a 320 meters long iron construction located near the Champ de Mars, in the central part of the city. The tower was designed and built at the end of the 19th century by a famous French civil engineer Gustave Eiffel. The idea of building the tower was to attract attention to one of the local fairs taking place in Paris, so the tower was built and located in the central part of the city in order to increase the number of visitors and tourists.', 0, 0, N'bb97904f-d17d-4871-9db7-93838592b768', N'https://photonproject.blob.core.windows.net/publications/paris.jpg')
INSERT [dbo].[Publications] ([Id], [IsDeleted], [Title], [Price], [coordX], [coordY],  [PublicationDate], [Season], [TextDescription], [LikeCount], [IsApproved], [UserId], [ImageLink]) VALUES (2, 0, N'London', 100, CAST(51.51 AS Decimal(18, 2)), CAST(-0.12 AS Decimal(18, 2)),  CAST(N'2020-06-03T00:00:00.0000000' AS DateTime2), 2, N'The Houses of Parliament (Palace of Westminster) is, of course, one of the most popular buildings to photograph for Instagram. For some of the best spots go directly opposite and take pictures in this little archway and also the steps above that lead from Westminster Bridge down to the walkway. The best bet for good photographs is to get here around sunset for the golden hour as the sun often sets behind the building. It is also common to see wedding photographers here doing a photoshoot with brides and grooms.', 0, 0, N'bb97904f-d17d-4871-9db7-93838592b768', N'https://photonproject.blob.core.windows.net/publications/london.jpg')
INSERT [dbo].[Publications] ([Id], [IsDeleted], [Title], [Price], [coordX], [coordY],  [PublicationDate], [Season], [TextDescription], [LikeCount], [IsApproved], [UserId], [ImageLink]) VALUES (3, 0, N'Kharkiv', 50, CAST(49.98 AS Decimal(18, 2)), CAST(36.25 AS Decimal(18, 2)),  CAST(N'2020-06-01T00:00:00.0000000' AS DateTime2), 2, N'Gorky Park – one of the brightest sights of Kharkiv. A walk in the park with friends or beloved person will give not only a lot of emotions but also unforgettable photos. Particularly charming they look in the dark when the lights are already lit, and the light completely changes the overall mood of the frame.', 0, 0, N'17c05e72-615d-4375-b89a-f0c82a0fc03d', N'https://photonproject.blob.core.windows.net/publications/kharkiv.jpg')
INSERT [dbo].[Publications] ([Id], [IsDeleted], [Title], [Price], [coordX], [coordY], [PublicationDate], [Season], [TextDescription], [LikeCount], [IsApproved], [UserId], [ImageLink]) VALUES (4, 0, N'Kiev', 20, CAST(50.45 AS Decimal(18, 2)), CAST(30.52 AS Decimal(18, 2)),  CAST(N'2020-06-01T00:00:00.0000000' AS DateTime2), 3, N'You can arrive here with public transport or on your own. Very crowded place at weekends. It might be hard to find place at parking. Path to the top starts at the museum. Climbing costs about 8 USD, but you should pay in UAH. Only 4 persons plus guide can climb to the top at once. Sometimes it causes waiting lines. So it''s better to arrive here before noon. It''s better for you if you are in a good physical shape. Some part of climbin you have to do with your own legs and arms by metal ladder.Only 18+ persons allowed', 0, 0, N'17c05e72-615d-4375-b89a-f0c82a0fc03d', N'https://photonproject.blob.core.windows.net/publications/kiev.jpg')
SET IDENTITY_INSERT [dbo].[Publications] OFF
GO
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
