using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class AddListTTRepository : GenericRepository<AddListTT>, IAddListTTRepository
{
    public ICollection<AddListTT>? GetAllWithPerson()
    {
        return _context?.AddListTTs.Include(x => x.Person).ToList();
    }

    public ICollection<AddListTT>? GetAllWithTop250Movie()
    {
        return _context?.AddListTTs.Include(x => x.Top250TvShow).ToList();
    }
}
