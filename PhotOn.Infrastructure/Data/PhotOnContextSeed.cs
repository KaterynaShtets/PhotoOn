using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhotOn.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotOn.Infrastructure.Data
{
    public class PhotOnContextSeed
    {
        public static async Task SeedAsync(PhotOnContext photonContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {

                photonContext.Database.Migrate();
                photonContext.Database.EnsureCreated();

                if (!photonContext.Users.Any())
                {
                    photonContext.Users.AddRange(GetPreconfiguredApplicationUsers());
                    await photonContext.SaveChangesAsync();
                }
                if (!photonContext.Roles.Any())
                {
                    photonContext.Roles.AddRange(GetPreconfiguredRoles());
                    await photonContext.SaveChangesAsync();
                }
                if (!photonContext.UserRoles.Any())
                {
                    photonContext.UserRoles.AddRange(GetPreconfiguredUserRoles());
                    await photonContext.SaveChangesAsync();
                }

                if (!photonContext.Publications.Any())
                {
                    photonContext.Publications.AddRange(GetPreconfiguredPublications());
                    await photonContext.SaveChangesAsync();
                }

                if (!photonContext.Tags.Any())
                {
                    photonContext.Tags.AddRange(GetPreconfiguredTags());
                    await photonContext.SaveChangesAsync();
                }

                if (!photonContext.Equipment.Any())
                {
                    photonContext.Equipment.AddRange(GetPreconfiguredEquipment());
                    await photonContext.SaveChangesAsync();
                }

                if (!photonContext.Events.Any())
                {
                    photonContext.Events.AddRange(GetPreconfigureEvents());
                    await photonContext.SaveChangesAsync();
                }

                
                //if (!photonContext.PublicationEquipments.Any())
                //{
                //    photonContext.PublicationEquipments.AddRange(GetPreconfiguredPublicationEquipment());
                //    await photonContext.SaveChangesAsync();
                //}
              


                //if (!photonContext.PublicationTags.Any())
                //{
                //    photonContext.PublicationTags.AddRange(GetPreconfiguredPublicationTag());
                //    await photonContext.SaveChangesAsync();
                //}
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<PhotOnContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(photonContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<Publication> GetPreconfiguredPublications()
        {
            return new List<Publication>()
            {
                new Publication() {
                    Title = "Kharkiv",
                    Price = 50,
                    coordX =  49.9808m,
                    coordY = 36.2527m,
                    PublicationDate = new DateTime(2020, 06, 01),
                    Season = TimeOfTheYear.Spring,
                    TextDescription = "Gorky Park – one of the brightest sights of Kharkiv. A walk in the park with friends or beloved person will give not only a lot of emotions but also unforgettable photos. Particularly charming they look in the dark when the lights are already lit, and the light completely changes the overall mood of the frame.",
                    UserId = "56343e64-bb55-4c56-b8a6-61c7a5d60a3d",
                    ImageLink = "https://photonproject.blob.core.windows.net/publications/kharkiv.jpg"
                },
               new Publication() {
                    Title = "London",
                    Price = 100,
                    coordX = 51.509865m,
                    coordY = -0.118092m,
                    PublicationDate = new DateTime(2020, 06, 03),
                    TextDescription = "The Houses of Parliament (Palace of Westminster) is, of course, one of the most popular buildings to photograph for Instagram. For some of the best spots go directly opposite and take pictures in this little archway and also the steps above that lead from Westminster Bridge down to the walkway. The best bet for good photographs is to get here around sunset for the golden hour as the sun often sets behind the building. It is also common to see wedding photographers here doing a photoshoot with brides and grooms.",
                    Season = TimeOfTheYear.Spring,
                    UserId = "56343e64-bb55-4c56-b8a6-61c7a5d60a3d",
                    ImageLink = "https://photonproject.blob.core.windows.net/publications/london.jpg"
                },
               new Publication() {
                    Title = "Paris",
                    Price = 200,
                    coordX = 48.858093m,
                    coordY = 2.294694m,
                    PublicationDate = new DateTime(2020, 06, 02),
                    TextDescription = "Known as the most visited tourist attraction in Europe, the Eiffel Tower is considered one of the most recognizable and favorite landmarks of the modern world. The symbol of Paris and the whole of France, the Eiffel Tower is a 320 meters long iron construction located near the Champ de Mars, in the central part of the city. The tower was designed and built at the end of the 19th century by a famous French civil engineer Gustave Eiffel. The idea of building the tower was to attract attention to one of the local fairs taking place in Paris, so the tower was built and located in the central part of the city in order to increase the number of visitors and tourists.",
                    Season = TimeOfTheYear.Spring,
                    UserId = "0db66fbe-afb2-4c2f-b1b3-bcb472442a55",
                    ImageLink = "https://photonproject.blob.core.windows.net/publications/paris.jpg"
                },
               new Publication() {
                    Title = "Kiev",
                    Price = 20,
                    coordX = 50.45466m,
                    coordY = 30.5238m,
                    PublicationDate = new DateTime(2020, 06, 01),
                    TextDescription = "You can arrive here with public transport or on your own. Very crowded place at weekends. It might be hard to find place at parking. Path to the top starts at the museum. Climbing costs about 8 USD, but you should pay in UAH. Only 4 persons plus guide can climb to the top at once. Sometimes it causes waiting lines. So it's better to arrive here before noon. It's better for you if you are in a good physical shape. Some part of climbin you have to do with your own legs and arms by metal ladder.Only 18+ persons allowed",
                    Season = TimeOfTheYear.Summer,
                    UserId = "0db66fbe-afb2-4c2f-b1b3-bcb472442a55",
                    ImageLink = "https://photonproject.blob.core.windows.net/publications/kiev.jpg"
                }
            };
        }

        private static IEnumerable<Equipment> GetPreconfiguredEquipment()
        {
            return new List<Equipment>()
            {
                new Equipment() {
                    Title = "PhotoCamera"
                },
                new Equipment() {
                    Title = "VideoCamera"
                }
            };
        }

        private static IEnumerable<Tag> GetPreconfiguredTags()
        {
            return new List<Tag>()
            {
                new Tag() {
                    Title = "Paris"
                },
                new Tag() {
                    Title = "London"
                },
                new Tag() {
                    Title = "Kiev"
                },
                new Tag() {
                    Title = "Kharkiv"
                }
            };
        }

        private static IEnumerable<ApplicationUser> GetPreconfiguredApplicationUsers()
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser() {
                    Id = "0db66fbe-afb2-4c2f-b1b3-bcb472442a55",
                    Email = "photon.adm@gmail.com",
                    DOB = new DateTime(1985,06,1),
                    PasswordHash = "AQAAAAEAACcQAAAAEPY10dUv8crQgkUaA3SgFRvkvTc/+SUwrUb1vc7Q0X31GT+Bg4D9BuvoyG6YYPfAaw==",
                },
                new ApplicationUser() {
                    Id = "56343e64-bb55-4c56-b8a6-61c7a5d60a3d",
                    Email = "photon.exp@gmail.com",
                    DOB = new DateTime(1970, 06, 2),
                    PasswordHash = "AQAAAAEAACcQAAAAEPY10dUv8crQgkUaA3SgFRvkvTc/+SUwrUb1vc7Q0X31GT+Bg4D9BuvoyG6YYPfAaw==",
        },
                new ApplicationUser() {
                    Id = "8d102a82-40a8-4771-9c4d-2a3c8897ac6d",
                    Email = "photon.use@gmail.com",
                    DOB = new DateTime(1988, 09, 3),
                    PasswordHash = "AQAAAAEAACcQAAAAEPY10dUv8crQgkUaA3SgFRvkvTc/+SUwrUb1vc7Q0X31GT+Bg4D9BuvoyG6YYPfAaw==",
                },
            };
        }

        private static IEnumerable<IdentityRole> GetPreconfiguredRoles()
        {
            return new List<IdentityRole>()
            {
                new IdentityRole() {
                    Id = "4cc0d7db-a3d6-4290-8b63-34df7756a583",
                    Name = "Admin",
                },
                new IdentityRole() {
                    Id = "58b4fbe9-035a-4d8d-ae54-22fc55e27fbb",
                    Name = "User",
                },
                new IdentityRole() {
                    Id = "1dbecfbd-1cb2-4364-a2c1-f0734e8ec909",
                    Name = "Expert",
                },
                 new IdentityRole() {
                    Id = "2dbecfbd-1cb2-4364-a2c1-f0734e8ec909",
                    Name = "Banned",
                },
            };
        }

        private static IEnumerable<Event> GetPreconfigureEvents()
        {
            return new List<Event>()
            {
                new Event()
                {
                    AwardTitle = "Nake a shot at London",
                    TagId = 3,
                    TextDescription = "Add 3 tag and win a award. We are waiting for you",
                    DateTime = new DateTime(2020,06,12),
                    ImageLink = "https://photonproject.blob.core.windows.net/publications/photo-1513635269975-59663e0ac1ad.jpg"
                }
            };
        }

        private static IEnumerable<IdentityUserRole<string>> GetPreconfiguredUserRoles()
        {
            return new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>() {
                    UserId = "0db66fbe-afb2-4c2f-b1b3-bcb472442a55",
                    RoleId = "4cc0d7db-a3d6-4290-8b63-34df7756a583",
                },
                new IdentityUserRole<string>() {
                    UserId = "8d102a82-40a8-4771-9c4d-2a3c8897ac6d",
                    RoleId = "58b4fbe9-035a-4d8d-ae54-22fc55e27fbb",
                },
                new IdentityUserRole<string>() {
                    UserId = "56343e64-bb55-4c56-b8a6-61c7a5d60a3d",
                    RoleId = "1dbecfbd-1cb2-4364-a2c1-f0734e8ec909",
                },
            };
        }

        private static IEnumerable<PublicationEquipment> GetPreconfiguredPublicationEquipment()
        {
            return new List<PublicationEquipment>()
                {
                    new PublicationEquipment() {
                        PublicationId = 1,
                        EquipmentId = 1
                    },
                    new PublicationEquipment() {
                        PublicationId = 2,
                        EquipmentId = 2
                    },
                     new PublicationEquipment() {
                        PublicationId = 3,
                        EquipmentId = 1
                    },
                    new PublicationEquipment() {
                        PublicationId = 4,
                        EquipmentId = 2
                    }

                };
        }

        private static IEnumerable<PublicationTag> GetPreconfiguredPublicationTag()
        {
            return new List<PublicationTag>()
                {
                    new PublicationTag() {
                        PublicationId = 1,
                        TagId = 4
                    },
                    new PublicationTag() {
                        PublicationId = 2,
                        TagId = 2
                    },
                    new PublicationTag() {
                        PublicationId = 3,
                        TagId = 1
                    },
                    new PublicationTag() {
                        PublicationId = 4,
                        TagId = 3
                    }
                };
        }
    }
}
