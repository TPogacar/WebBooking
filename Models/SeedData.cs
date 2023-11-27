using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebBooking.Data;
using System;
using System.Linq;

namespace WebBooking.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApiContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApiContext>>()))
            {
                // Look for any rooms
                if (context.Rooms.Any())
                {
                    return;   // DB has been seeded
                }

                //if (!context.Images.Any())
                //{
                //    context.Images.AddRange(
                //        new Image
                //        {
                //            Name = "room1",
                //            Content = File.ReadAllBytes(@"D:\preizkus_znanja\booking\WebBooking\seedDataImages\room1.jpg")
                //        },
                //        new Image
                //        {
                //            Name = "room2",
                //            Content = File.ReadAllBytes(@"D:\preizkus_znanja\booking\WebBooking\seedDataImages\room2.jpg")
                //        },
                //        new Image
                //        {
                //            Name = "room3",
                //            Content = File.ReadAllBytes(@"D:\preizkus_znanja\booking\WebBooking\seedDataImages\room3.jpg")
                //        },
                //        new Image
                //        {
                //            Name = "room4",
                //            Content = File.ReadAllBytes(@"D:\preizkus_znanja\booking\WebBooking\seedDataImages\room4.jpg")
                //        }
                //        );
                //}

                context.Rooms.AddRange(
                    new Room
                    {
                        Name = "Prva soba",
                        PricePerNight = 10,
                        ShortDescription = "Prva soba na levi",
                        Description = "Lepa soba ima lasno posteljo in kopalnico.",
                        AllImage = new List<Image> { new Image
                        {
                            Name = "room1",
                            Content = File.ReadAllBytes(@"D:\preizkus_znanja\booking\WebBooking\seedDataImages\room1.jpg")
                        } }
                    },
                    new Room
                    {
                        Name = "Druga soba",
                        PricePerNight = 10,
                        ShortDescription = "Druga soba na desni",
                        Description = "Lepa soba ima lasno posteljo in kopalnico. Ponaša se s prečudovitim pogledom na morje."
                    },
                    new Room
                    {
                        Name = "Nova soba",
                        PricePerNight = 10,
                        ShortDescription = "Nova soba",
                        Description = "Na novo opremljena soba",
                        AllImage = new List<Image> { new Image
                        {
                            Name = "room2",
                            Content = File.ReadAllBytes(@"D:\preizkus_znanja\booking\WebBooking\seedDataImages\room2.jpg")
                        },
                        new Image
                        {
                            Name = "room3",
                            Content = File.ReadAllBytes(@"D:\preizkus_znanja\booking\WebBooking\seedDataImages\room3.jpg")
                        } }
                    },
                    new Room
                    {
                        Name = "Stara soba",
                        PricePerNight = 10,
                        ShortDescription = "Stara soba",
                        Description = "Zelo stara soba s pogledom na parkirišče."
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
