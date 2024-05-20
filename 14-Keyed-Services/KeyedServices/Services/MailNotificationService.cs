namespace KeyedServices.Services
{
    public class MailNotificationService : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Sending mail notification {message}");
        }
    }
}
