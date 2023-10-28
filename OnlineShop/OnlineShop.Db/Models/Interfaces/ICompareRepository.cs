using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface ICompareRepository : IBaseRepository<Compare> 
    {
        Task ClearAsync(string userName);
    }
}