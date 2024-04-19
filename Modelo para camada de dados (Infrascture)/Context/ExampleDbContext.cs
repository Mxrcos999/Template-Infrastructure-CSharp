using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Modelo_para_camada_de_dados__Infrascture_.Context;

public class ExampleDbContext : DbContext
{
    public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options) { }
    public DbSet<Cliente> Clientes { get; set; }

}


public class ExampleDbContextFactory : IDesignTimeDbContextFactory<ExampleDbContext>
{
    public ExampleDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ExampleDbContext>();
        optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=testeDb;Username=postgres;Password=1234");

        return new ExampleDbContext(optionsBuilder.Options);
    }
}

