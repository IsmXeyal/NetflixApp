using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    public ICollection<Person>? GetAllWithAddListECs()
    {
        return _context?.People.Include(x => x.AddListECs).ToList();
    }

    public ICollection<Person>? GetAllWithAddListMPMs()
    {
        return _context?.People.Include(x => x.AddListMPMs).ToList();
    }

    public ICollection<Person>? GetAllWithAddListMpTs()
    {
        return _context?.People.Include(x => x.AddListMpTs).ToList();
    }

    public ICollection<Person>? GetAllWithAddListTMs()
    {
        return _context?.People.Include(x => x.AddListTMs).ToList();
    }

    public ICollection<Person>? GetAllWithAddListTTs()
    {
        return _context?.People.Include(x => x.AddListTTs).ToList();
    }
}
