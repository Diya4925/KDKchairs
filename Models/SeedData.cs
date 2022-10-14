using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using chairs.Data;

namespace chairs.Models
{
    public static class SeedData
    {
        public static void Initialize (IServiceProvider serviceProvider)
        {
            using (var context = new chairsContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<chairsContext>>()))
            {
                if (context.Chairs.Any())
                {
                    return; //DB has been seeded
                }

                context.Chairs.AddRange(
                    new Chairs
                    {
                        Name = "Recliner",
                        Type = "Leathers",
                        Colour = "Dark Brown",
                        Height = "4 feet",
                        Price = 49.99M
                    },
                    new Chairs
                    {
                        Name = "Bar Stool",
                        Type = "Plastic",
                        Colour = "Black and white",
                        Height = "4.5 feet",
                        Price = 19.99M
                    },
                    new Chairs
                    {
                        Name = "Ghost Chairs",
                        Type = "Plastic",
                        Colour = "Transparent/Clear",
                        Height = "3 feet",
                        Price = 9.99M
                    },
                    new Chairs
                    {
                        Name = "Office Chairs",
                        Type = "Wood and fabric",
                        Colour = "Deep Blue",
                        Height = "5 feet",
                        Price = 56.99M
                    },
                    new Chairs
                    {
                        Name = "Club Chairs",
                        Type = "Leathers",
                        Colour = "Black",
                        Height = "5 feet",
                        Price = 69.99M
                    },
                    new Chairs
                    {
                        Name = "Ottoman",
                        Type = "Wood",
                        Colour = "Dark Brown",
                        Height = "1 feet",
                        Price = 12.99M
                    },
                    new Chairs
                    {
                        Name = "Panton Chair",
                        Type = "Plastic",
                        Colour = "Yellow and Red",
                        Height = "4 feet",
                        Price = 9.99M
                    },
                    new Chairs
                    {
                        Name = "Sun Loungers",
                        Type = "Wood",
                        Colour = "Black",
                        Height = "7 feet",
                        Price = 50.45M
                    },
                    new Chairs
                    {
                        Name = "Wing Chairs",
                        Type = "Fabric and wood",
                        Colour = "Floral print",
                        Height = "3 feet",
                        Price = 38.99M
                    },

                    new Chairs
                    {
                        Name = "Plastic Arm Chair",
                        Type = "Plastic",
                        Colour = "Blue",
                        Height = "3 feet",
                        Price = 18.99M
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
