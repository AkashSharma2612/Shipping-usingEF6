using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shipping_Web__Apis.DataAccess;
using Shipping_Web__Apis.Repository;
using Shipping_Web__Apis.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string cs = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(cs));
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IShipFromAddressRepository, ShipFromAddressRepository>();
builder.Services.AddScoped<IShipToAddressRepository, ShipToAddressRepository>();
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
builder.Services.AddScoped<IShipmentPackageRepository, ShipmentPackageRepository>();

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
