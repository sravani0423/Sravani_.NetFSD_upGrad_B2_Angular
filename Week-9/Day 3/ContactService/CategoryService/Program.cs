using CategoryService.Data;
using Microsoft.EntityFrameworkCore;
using CategoryService.Repositories;
using CategoryService.Services;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<CategoryDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection (IMPORTANT)
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService.Services.CategoryService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();