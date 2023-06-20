using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface ICompareRepository
    {
        Task<IEnumerable<Compare>> AllCompares();
        Task<Compare> TryGetByCompareId(string compareId);
        Task Add(Product product, string compareId);
        Task DeleteItem(Guid id, string compareId);
        Task Clear(string compareId);
    }
}