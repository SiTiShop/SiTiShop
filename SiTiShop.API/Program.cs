using SiTiShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using SiTiShop.Data.Repositories.CategoryRepo;
using SiTiShop.Business.Service.CategoryService;
using SiTiShop.Data.Repositories.GenericRepository;
using NuGet.Protocol.Core.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Connect Database
builder.Services.AddDbContext<SiTiShopContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Subcribe service
builder.Services.AddScoped<ICategoryService, CategoryService>();

//Subcribe repository
builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();






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
