using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace OrangeOrchard.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OrangeOrchardContext(
                serviceProvider.GetRequiredService<DbContextOptions<OrangeOrchardContext>>()))
            {
                // Look for any movies.
                if (context.Tree.Any())
                {
                    return;   // DB has been seeded
                }

                context.Tree.AddRange(
                     new Tree
                     {
                         Title = "OrangeTree1",
                         YearPlanted = DateTime.Parse("1989"),
                         Age = 28,
                         Height = 10,
                         NumOranges = 20
                     },

                     new Tree
                     {
                         Title = "Ghostbusters ",
                         ReleaseDate = DateTime.Parse("1984-3-13"),
                         Genre = "Comedy",
                         Price = 8.99M,
                         Rating = "PG"
                     },

                     new Tree
                     {
                         Title = "Ghostbusters 2",
                         ReleaseDate = DateTime.Parse("1986-2-23"),
                         Genre = "Comedy",
                         Price = 9.99M,
                         Rating = "PG13+"
                     },

                   new Tree
                   {
                       Title = "Rio Bravo",
                       ReleaseDate = DateTime.Parse("1959-4-15"),
                       Genre = "Western",
                       Price = 3.99M,
                       Rating = "G"
                   }
                );
                context.SaveChanges();
            }
        }
    }
}