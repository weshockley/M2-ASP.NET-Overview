using Microsoft.AspNetCore.Server.HttpSys;

var builder = WebApplication.CreateBuilder(args);

// Here we enable the use of HTTP.sys web server if we supplied --EnableHttpSys command argument
// Run this command to use Kestrel:  dotnet run 
// Run this command to use HTTP.sys: dotnet run --EnableHttpSys
if (args.Any(argument => argument.Equals("--EnableHttpSys", StringComparison.InvariantCultureIgnoreCase)))
{
    Console.WriteLine("Enabling HTTP.sys");
    builder.WebHost.UseHttpSys(options =>
    {
        options.AllowSynchronousIO = false;
        options.Authentication.Schemes = AuthenticationSchemes.None;
        options.Authentication.AllowAnonymous = true;
        options.MaxConnections = null;
        options.MaxRequestBodySize = 30000000;
        options.UrlPrefixes.Clear();
        options.UrlPrefixes.Add("http://localhost:5005");
    });
}

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
