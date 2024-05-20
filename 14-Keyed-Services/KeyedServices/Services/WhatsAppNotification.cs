namespace KeyedServices.Services
{
    public class WhatsAppNotification : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Sending WhatsApp notification {message}");
        }
    }
}
