using CodersZahidul.DataAccess.Data;
using CodersZahidul.DataAccess.Repository;
using CodersZahidulWebAPI.Models;
using CodersZahidulWebAPI.Repository.IRepository;

namespace CodersZahidulWebAPI.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(ShoppingCart obj)
        {
            _db.shoppingCarts.Update(obj);
            await Task.CompletedTask;
        }
    }
}
