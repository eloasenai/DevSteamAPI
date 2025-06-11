using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using vetsys.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<vetsysContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("vetsysContext") ?? throw new InvalidOperationException("Connection string 'vetsysContext' not found.")));


// Adicionar o serviço de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors("AllowAll"); // Habilita o CORS 

app.UseAuthorization();

app.MapControllers();

app.Run();
