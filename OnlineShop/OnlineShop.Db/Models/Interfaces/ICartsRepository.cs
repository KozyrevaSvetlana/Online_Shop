using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface ICartsRepository : IBaseRepository<Cart>
    {
        Task ChangeAmount(Product product, int sign, string userId);
        Task<bool> IsInCart(Product product);
    }
}