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

                if (!photonContext.Events.Any())
                {
                    photonContext.Events.AddRange(GetPreconfigureEvents());
                    await photonContext.SaveChangesAsync();
                }

                if (!photonContext.Equipment.Any())
                {
                    photonContext.Equipment.AddRange(GetPreconfiguredEquipment());
                    await photonContext.SaveChangesAsync();
                }
                if (!photonContext.PublicationEquipments.Any())
                {
                    photonContext.PublicationEquipments.AddRange(GetPreconfiguredPublicationEquipment());
                    await photonContext.SaveChangesAsync();
                }
                if (!photonContext.Tags.Any())
                {
                    photonContext.Tags.AddRange(GetPreconfiguredTags());
                    await photonContext.SaveChangesAsync();
                }


                if (!photonContext.PublicationTags.Any())
                {
                    photonContext.PublicationTags.AddRange(GetPreconfiguredPublicationTag());
                    await photonContext.SaveChangesAsync();
                }
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
                    Price = 0,
                    coordX = 1.234m,
                    coordY = 3.454m,
                    PublicationDate = new DateTime(2020, 02, 23),
                    Season = TimeOfTheYear.Spring,
                    TextDescription = "",
                    LikeCount = 0,
                    UserId = "56343e64-bb55-4c56-b8a6-61c7a5d60a3d",
                    ImageLink = ""
                },
               new Publication() {
                    Title = "London",
                    Price = 0,
                    coordX = 1.234m,
                    coordY = 3.454m,
                    PublicationDate = new DateTime(2020, 02, 23),
                    TextDescription = "",
                    Season = TimeOfTheYear.Spring,
                    LikeCount = 0,
                    UserId = "56343e64-bb55-4c56-b8a6-61c7a5d60a3d",
                    ImageLink = ""
                },
               new Publication() {
                    Title = "Paris",
                    Price = 0,
                    coordX = 1.234m,
                    coordY = 3.454m,
                    PublicationDate = new DateTime(2020, 02, 23),
                    TextDescription = "",
                    Season = TimeOfTheYear.Spring,
                    LikeCount = 0,
                    UserId = "0db66fbe-afb2-4c2f-b1b3-bcb472442a55",
                    ImageLink = ""
                },
               new Publication() {
                    Title = "Kiev",
                    Price = 0,
                    coordX = 1.234m,
                    coordY = 3.454m,
                    PublicationDate = new DateTime(2020, 02, 23),
                    Season = TimeOfTheYear.Spring,
                    LikeCount = 0,
                    UserId = "0db66fbe-afb2-4c2f-b1b3-bcb472442a55",
                    ImageLink = ""
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
                    Email = "katetkacenko@gmail.com",
                    DOB = new DateTime(20,06,1),
                    PasswordHash = "AQAAAAEAACcQAAAAEFEE6EMSLVfi6QJCco6xbW0CPCgan6Vl/aN6LInRcQ+HxhwT4i1ZwGXiF8eu+c/B/Q==",
                },
                new ApplicationUser() {
                    Id = "56343e64-bb55-4c56-b8a6-61c7a5d60a3d",
                    Email = "katetkacenko@gmail.com",
                    DOB = new DateTime(20, 06, 2),
                    PasswordHash = "AQAAAAEAACcQAAAAEFEE6EMSLVfi6QJCco6xbW0CPCgan6Vl/aN6LInRcQ+HxhwT4i1ZwGXiF8eu+c/B/Q==",
        },
                new ApplicationUser() {
                    Id = "8d102a82-40a8-4771-9c4d-2a3c8897ac6d",
                    Email = "katetkacenko@gmail.com",
                    DOB = new DateTime(18, 09, 3),
                    PasswordHash = "AQAAAAEAACcQAAAAEFEE6EMSLVfi6QJCco6xbW0CPCgan6Vl/aN6LInRcQ+HxhwT4i1ZwGXiF8eu+c/B/Q==",
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
            };
        }

        private static IEnumerable<Event> GetPreconfigureEvents()
        {
            return new List<Event>()
            {
                new Event()
                {
                    AwardTitle = "BestShot",
                    TagId = 3,
                    TextDescription = "Add 3 tag",
                    DateTime = new DateTime(2020,06,12)
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
                    UserId = "56343e64-bb55-4c56-b8a6-61c7a5d60a3d",
                    RoleId = "58b4fbe9-035a-4d8d-ae54-22fc55e27fbb",
                },
                new IdentityUserRole<string>() {
                    UserId = "8d102a82-40a8-4771-9c4d-2a3c8897ac6d",
                    RoleId = "1dbecfbd-1cb2-4364-a2c1-f0734e8ec909",
                },
            };
        }

        private static IEnumerable<PublicationEquipment> GetPreconfiguredPublicationEquipment()
        {
            return new List<PublicationEquipment>()
                {
                    new PublicationEquipment() {
                        PublicationId = 42,
                        EquipmentId = 3
                    },
                    new PublicationEquipment() {
                        PublicationId = 43,
                        EquipmentId = 4
                    },
                     new PublicationEquipment() {
                        PublicationId = 44,
                        EquipmentId = 3
                    },
                    new PublicationEquipment() {
                        PublicationId = 45,
                        EquipmentId = 4
                    }

                };
        }

        private static IEnumerable<PublicationTag> GetPreconfiguredPublicationTag()
        {
            return new List<PublicationTag>()
                {
                    new PublicationTag() {
                        PublicationId = 42,
                        TagId = 6
                    },
                    new PublicationTag() {
                        PublicationId = 43,
                        TagId = 4
                    },
                    new PublicationTag() {
                        PublicationId = 44,
                        TagId = 3
                    },
                    new PublicationTag() {
                        PublicationId = 45,
                        TagId = 5
                    }
                };
        }
    }
}
