using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface ICartsRepository
    {
        Task ChangeAmountAsync(Product product, int sign, string userId);
        Task<bool> IsInCartAsync(Product product);

        Task ClearAsync(string UserName);
    }
}