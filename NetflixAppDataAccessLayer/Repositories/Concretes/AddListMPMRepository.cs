using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class AddListMPMRepository : GenericRepository<AddListMPM>, IAddListMPMRepository
{
    public ICollection<AddListMPM>? GetAllWithMostPopularMovie()
    {
        return _context?.AddListMPMs.Include(x => x.MostPopularMovie).ToList();
    }

    public ICollection<AddListMPM>? GetAllWithPerson()
    {
        return _context?.AddListMPMs.Include(x => x.Person).ToList();
    }
}
