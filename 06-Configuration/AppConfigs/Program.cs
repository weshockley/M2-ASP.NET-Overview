var configsDictionary = new Dictionary<string, string>
    {
        {"emailSettings:server", "smtp.example.com.array"},
        {"emailSettings:from", "smtp.example.com.from"},
    };

var builder = WebApplication.CreateBuilder(args);

// HACK Configuration: Explain how to have multiple configurations
// How the override works bottom to top.
builder.Configuration.AddInMemoryCollection(configsDictionary);
builder.Configuration.AddIniFile("app_configs.ini", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile("app_configs.json", optional: false, reloadOnChange: true);
builder.Configuration.AddXmlFile("app_configs.xml", optional: false, reloadOnChange: true);
builder.Configuration.AddCommandLine(args);

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();