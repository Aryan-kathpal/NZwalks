using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NZwalks.API.Data;
using NZwalks.API.Mapper;
using NZwalks.API.Repositeries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WalksDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("db"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("db"))));
builder.Services.AddAutoMapper(options=>options.AddMaps(typeof(AutoMapperProfiles).Assembly));
builder.Services.AddScoped<IRegionInterface, RegionRepoNew>();
builder.Services.AddScoped<INZwalk, NZwalkRepo>();

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
