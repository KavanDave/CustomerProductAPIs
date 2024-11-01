
using CustomerProductAPIs.Libraries;
using CustomerProductAPIs.Models;
using CustomerProductAPIs.Properties.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IqueryDB,queryDB>();
builder.Services.AddScoped<IcustomerLibrary, customerLibrary>();
builder.Services.AddScoped<IproductsLibrary, ProductsLibrary>();
builder.Services.AddDbContext<NewCustomerProdContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("newCustomerProd")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
