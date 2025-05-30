using BFF.Web.Config;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Eureka;
using Ocelot.Provider.Polly;

var builder = WebApplication.CreateBuilder(args);

var routes = "Routes.dev";

// Include swagger on api gateway using ocelot
builder.Configuration.AddOcelotWithSwaggerSupport(options =>
{
    options.Folder = routes;
});

builder.Services.AddOcelot(builder.Configuration).AddPolly().AddEureka();
builder.Services.AddSwaggerForOcelot(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BFF.Web");
        c.RoutePrefix = "bffweb"; 
    });
}

// For swagger in api gateway
app.UseSwaggerForOcelotUI(options =>
{
    options.PathToSwaggerGenerator = "/swagger/docs";
    options.ReConfigureUpstreamSwaggerJson = AlterUpstream.AlterUpstreamSwaggerJson;
});

app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments("/api/health", StringComparison.OrdinalIgnoreCase), builder =>
{
    builder.UseRouting();
    builder.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
});

await app.UseOcelot();

app.Run();


