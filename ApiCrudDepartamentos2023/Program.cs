using ApiCrudDepartamentos2023.Data;
using ApiCrudDepartamentos2023.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Departamentos",
        Description = "Realiza todas las funciones de Insertar, modificar o borrar datos de los departamentos de la BBDD",
        Version = "v1",
        Contact = new OpenApiContact()
        {
            Name = "Domingo Castro Ca?ete",
            Email = "Domingocastro1998@gmail.com"
        }
    });
});
string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryDepartamentos>();
builder.Services.AddDbContext<DepartamentosContext>(options => options.UseSqlServer(connectionString));
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api v1");
    options.RoutePrefix = "";
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
