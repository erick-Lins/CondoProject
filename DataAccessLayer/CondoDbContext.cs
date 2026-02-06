using CondoProj.Model;
using Microsoft.EntityFrameworkCore;

namespace CondoProj
{
    public class CondoDbContext : DbContext
    {
        public CondoDbContext(DbContextOptions<CondoDbContext> options)
            : base(options) { }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Tower> Towers { get; set; }
    }
}