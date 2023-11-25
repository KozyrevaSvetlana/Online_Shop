using System.Threading.Tasks;
using ModelsLibrary.ModelsDto;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IFavoritesRepository : IBaseRepository<Favorites> 
    {
        Task ClearAsync(string userName);
    }
}