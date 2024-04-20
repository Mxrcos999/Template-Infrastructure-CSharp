using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Modelo_para_camada_de_dados__Infrascture_.Context;

public class ExampleDbContext : DbContext
{
    public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options) { }

}


public class ExampleDbContextFactory : IDesignTimeDbContextFactory<ExampleDbContext>
{
    private readonly IConfiguration _configuration;

    public ExampleDbContextFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public ExampleDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ExampleDbContext>();
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));

        return new ExampleDbContext(optionsBuilder.Options);
    }
}

