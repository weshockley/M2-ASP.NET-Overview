namespace KeyedServices.Services
{
    public class PhoneNotificationService : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Sending phone notification : {message}");
        }
    }
}
