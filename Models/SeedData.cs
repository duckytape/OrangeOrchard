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
                // Look for any trees.
                if (context.Tree.Any())
                {
                    return;   // DB has been seeded
                }

                context.Tree.AddRange(
                     new Tree
                     {
                         Name = "OrangeTree1",
                         //YearPlanted = DateTime.Parse("1989"),
                         Age = 28,
                         //NumOranges = 20
                         Genre = "one",
                     },
                     new Tree
                     {
                         Name = "OrangeTree2",
                         //YearPlanted = DateTime.Parse("1989"),
                         Age = 28,
                         //NumOranges = 20
                         Genre = "two",
                     },
                    new Tree
                     {
                         Name = "OrangeTree3",
                         //YearPlanted = DateTime.Parse("1989"),
                         Age = 28,
                         //NumOranges = 20
                         Genre = "three",
                     }
                );
                context.SaveChanges();
            }
        }
    }
}