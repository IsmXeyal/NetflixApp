using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class AddListMpTRepository : GenericRepository<AddListMpT>, IAddListMpTRepository
{
    public ICollection<AddListMpT>? GetAllWithMostPopularTvShow()
    {
        return _context?.AddListMpTs.Include(x => x.MostPopularTvShow).ToList();
    }

    public ICollection<AddListMpT>? GetAllWithPerson()
    {
        return _context?.AddListMpTs.Include(x => x.Person).ToList();
    }
}
