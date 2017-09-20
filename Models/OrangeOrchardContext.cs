using Microsoft.EntityFrameworkCore;

namespace OrangeOrchard.Models
{
    public class OrangeOrchardContext : DbContext
    {
        public OrangeOrchardContext (DbContextOptions<OrangeOrchardContext> options)
            : base(options)
        {
        }

        public DbSet<OrangeOrchard.Models.Tree> Tree { get; set; }
    }
}