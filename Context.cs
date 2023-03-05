using Microsoft.EntityFrameworkCore;
using orm.Model.Entities;

namespace orm
{
    public class Context : DbContext
    {
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Residence> Residences { get; set; } = null!;
        public Context()
        {
           //Database.EnsureDeleted();
           //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5433;User Id=postgres;Password=1234;Database=BankORM;");
        }

    }

}
