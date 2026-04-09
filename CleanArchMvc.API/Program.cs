using CleanArchMvc.Infra.IoC;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
})
.AddXmlSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen
(
    c => c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CleanArchMvc.API",
        Description = "ASP.NET Core Web API for Clean Architecture",
        Contact = new OpenApiContact
        {
            Name = "Contact Name",
            Email = "contact@example.com",
        }
    })
);

builder.Services.AddInfrastructureAPI(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
