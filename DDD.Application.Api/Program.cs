using DDD.Infra.SqlServer;
using DDD.Infra.SqlServer.Interfaces;
using DDD.Infra.SqlServer.Repositories;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//IOC - Dependency Injection
builder.Services.AddScoped<IClinicaRepository, ClinicaRepository>();
builder.Services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();
builder.Services.AddScoped<SqlServerContext, SqlServerContext>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();

app.Run();
