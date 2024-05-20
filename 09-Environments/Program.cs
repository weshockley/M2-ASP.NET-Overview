var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // HACK Environments 1: We are registering here welcome page on /HelloDeveloper path if we run in Development
    app.UseWelcomePage(new WelcomePageOptions { Path = "/HelloDevelopment" });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();

    // HACK Environments 2: We are registering here welcome page on /HelloProduction path if we run in Production
    app.UseWelcomePage(new WelcomePageOptions { Path = "/HelloProduction" });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// HACK Environments 3: This middleware shows the currenly middleware.
app.Run(async context =>
{
    await context.Response.WriteAsync($"You are currenly running: {app.Environment.EnvironmentName} environment.");
});

app.MapRazorPages();

app.Run();