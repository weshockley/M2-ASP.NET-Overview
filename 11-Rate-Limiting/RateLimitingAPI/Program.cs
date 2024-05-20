using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Fixed time window rate limit: 5 requests per 10 seconds
const string fixedWindowPolicy = "FixedWindow";
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter(fixedWindowPolicy, o =>
    {
        o.PermitLimit = 5;
        o.Window = TimeSpan.FromSeconds(20);
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRateLimiter();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers().RequireRateLimiting(fixedWindowPolicy);
app.Run();
