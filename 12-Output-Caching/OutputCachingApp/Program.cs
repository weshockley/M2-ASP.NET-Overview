var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOutputCache();
builder.Services.AddOutputCache(options => 
    options.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(10));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseOutputCache();

// https://localhost:5001/weatherforecast?location=London
app.MapControllers().CacheOutput(options =>
{
    options.SetVaryByQuery("location");
    options.Expire(TimeSpan.FromSeconds(10));
});
app.Run();
