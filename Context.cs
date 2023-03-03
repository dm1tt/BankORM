using Microsoft.EntityFrameworkCore;
using orm.Model.Entities;

namespace orm
{
    public class Context : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Residence> Residences { get; set; }
        public DbSet<Telephone> Telephones { get; set; }

        public Context()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5433;User Id=postgres;Password=1234;Database=orm4;");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Residence>()
        //        .HasOne(c => c.Client)
        //        .WithOne(i => i.Residence)
        //        .HasForeignKey<Client>(r => r.ResidenceForeignKey);

        //    modelBuilder.Entity<Client>()
        //        .HasOne(c => c.Telephone)
        //        .WithMany(t => t.Clients)
        //        .HasForeignKey(r => r.TelephoneForeignKey);
        //}
    }

}
