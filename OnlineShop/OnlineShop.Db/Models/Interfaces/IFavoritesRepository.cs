using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IFavoritesRepository : IBaseRepository<Favorites> 
    {
        Task ClearAsync(string userName);
    }
}