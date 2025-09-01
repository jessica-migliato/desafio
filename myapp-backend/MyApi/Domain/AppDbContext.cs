using Microsoft.EntityFrameworkCore;
using MyApi.Domain.Entities;

namespace MyApi.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Titulo>()
                .HasMany(t => t.Parcelas)
                .WithOne()
                .HasForeignKey(p => p.TituloId);
        }
    }
}
