using Core.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Infra.Database;

public class ExemploDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }

    public ExemploDbContext(DbContextOptions<ExemploDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().ToTable("CLIENTES");
    }
}