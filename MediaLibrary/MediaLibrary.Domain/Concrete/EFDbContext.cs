using PirateThis.Domain.Entities;
using System.Data.Entity;

namespace PirateThis.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
