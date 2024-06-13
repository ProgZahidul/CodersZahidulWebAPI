using CodersZahidul.DataAccess.Repository.IRepository;
using CodersZahidul.Models;

namespace CodersZahidulWebAPI.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task UpdateAsync(Category obj);
    }
}
