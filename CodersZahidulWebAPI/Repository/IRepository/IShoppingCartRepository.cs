using CodersZahidul.DataAccess.Repository.IRepository;
using CodersZahidul.Models;
using CodersZahidulWebAPI.Models;

namespace CodersZahidulWebAPI.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        Task UpdateAsync(ShoppingCart obj);
    }
}
