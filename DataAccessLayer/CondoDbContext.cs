using CondoProj.Model;
using Microsoft.EntityFrameworkCore;

namespace CondoProj
{
    public class CondoDbContext : DbContext
    {
        public CondoDbContext(DbContextOptions<CondoDbContext> options)
            : base(options) { }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Tower> Towers { get; set; }
    }
}