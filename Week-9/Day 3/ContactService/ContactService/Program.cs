using ContactService.Data;
using Microsoft.EntityFrameworkCore;
using ContactService.Repositories;
using ContactService.Services;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<ContactDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService.Services.ContactService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();