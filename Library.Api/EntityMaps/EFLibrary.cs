using Library.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Api.EntityMaps
{
    public class EFLibrary :DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet <User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFLibrary).Assembly);
        }
    }
}
