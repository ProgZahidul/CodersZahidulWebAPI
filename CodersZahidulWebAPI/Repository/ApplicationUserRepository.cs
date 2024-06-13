using CodersZahidul.DataAccess.Data;
using CodersZahidul.DataAccess.Repository;
using CodersZahidul.Models;
using CodersZahidulWebAPI.Models;
using CodersZahidulWebAPI.Repository.IRepository;

namespace CodersZahidulWebAPI.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
