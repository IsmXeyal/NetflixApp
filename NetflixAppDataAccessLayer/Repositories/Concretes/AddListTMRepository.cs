using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class AddListTMRepository : GenericRepository<AddListTM>, IAddListTMRepository
{
    public ICollection<AddListTM>? GetAllWithPerson()
    {
        return _context?.AddListTMs.Include(x => x.Person).ToList();
    }

    public ICollection<AddListTM>? GetAllWithTop250Movie()
    {
        return _context?.AddListTMs.Include(x => x.Top250Movie).ToList();
    }
}
