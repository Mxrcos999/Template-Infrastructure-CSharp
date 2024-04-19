using Microsoft.EntityFrameworkCore;
using Modelo_para_application__Clean_arch_.Interfaces.Repository;
using Modelo_para_camada_de_dados__Infrascture_.Context;
using Modelo_para_camada_de_dados__Infrascture_.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ExampleDbContext>(opts => opts.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IRepoCliente, Repo>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddScoped<IRepoCliente, Repo>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
