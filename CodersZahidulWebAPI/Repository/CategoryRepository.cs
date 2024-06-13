using CodersZahidul.DataAccess.Data;
using CodersZahidul.DataAccess.Repository;
using CodersZahidul.Models;
using CodersZahidulWebAPI.Repository.IRepository;

namespace CodersZahidulWebAPI.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(Category obj)
        {
            _db.categories.Update(obj);
            await Task.CompletedTask;
        }
    }
}
