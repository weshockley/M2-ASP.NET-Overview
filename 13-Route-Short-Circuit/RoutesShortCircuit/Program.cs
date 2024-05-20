using RoutesShortCircuit.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseCustomMiddleware();
app.UseStaticFiles();

app.MapGet("/", () => "Hello from the API").ShortCircuit();
app.MapGet("_health", () => Results.Ok()).ShortCircuit();

app.MapShortCircuit(404, "robots.txt", "favicon.ico");

app.Run();
