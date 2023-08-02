using Udemy.Entity.Concrete;

namespace Udemy.WebUI.Service.CartService
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
