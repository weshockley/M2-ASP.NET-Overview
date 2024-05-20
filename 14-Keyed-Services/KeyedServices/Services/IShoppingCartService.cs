namespace KeyedServices.Services
{
    public interface IShoppingCartService
    {
        void AddToCart(string product);
        void ClearCart();
    }
}
