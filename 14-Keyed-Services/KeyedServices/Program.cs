using KeyedServices.Services;

namespace KeyedServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

           // builder.Services.AddSingleton<INotificationService, MailNotificationService>();
           // builder.Services.AddSingleton<INotificationService, PhoneNotificationService>();
            //builder.Services.AddSingleton<INotificationService, WhatsAppNotification>();

            builder.Services.AddKeyedSingleton<INotificationService, MailNotificationService>("mail");
            builder.Services.AddKeyedSingleton<INotificationService, PhoneNotificationService>("phone");
           
             builder.Services.AddKeyedSingleton<INotificationService, WhatsAppNotification>("whatsapp");

            builder.Services.AddSingleton<IShoppingCartService, ShoppingCartService>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
