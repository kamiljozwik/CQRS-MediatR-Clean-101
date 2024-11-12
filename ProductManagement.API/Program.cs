using FastEndpoints;
using FastEndpoints.Swagger;
using ProductManagement.Application;
using ProductManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(); //define a swagger document

var app = builder.Build();

// Configure the HTTP request pipeline.
// app.UseAuthorization();
app.UseFastEndpoints();  // Use FastEndpoints middleware
app.UseOpenApi();        // Serve OpenAPI/Swagger documents
app.UseSwaggerGen();     // Serve Swagger UI

app.Run();
