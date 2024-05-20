namespace KeyedServices.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly INotificationService _notificationService;
      //  public ShoppingCartService(INotificationService notificationService)
        //{
          //  _notificationService = notificationService;
        //}

        public ShoppingCartService([FromKeyedServices("mail")] INotificationService notificationService)
        {
            _notificationService = notificationService;
         }

        public void AddToCart(string product)
        {
            Console.WriteLine($"Adding {product} to the cart");
            // _notificationService.Notify($"Adding {product} to the cart");
        }

        public void ClearCart()
        {
            _notificationService.Notify("Cart cleared");
        }
    }
}
