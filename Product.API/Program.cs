using Microsoft.EntityFrameworkCore;
using Product.API.Database;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductContext>(optons => optons.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddServiceDiscovery(option => option.UseEureka());

var app = builder.Build();

//Seed Data Generation
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var db = services.GetRequiredService<ProductContext>();
    SeedDataProvider.Initialize(db);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();

