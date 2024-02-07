using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class AddListECRepository : GenericRepository<AddListEC>, IAddListECRepository
{
    public ICollection<AddListEC>? GetAllWithEditorChoice()
    {
        return _context?.AddListECs.Include(x => x.EditorChoice).ToList();
    }

    public ICollection<AddListEC>? GetAllWithPerson()
    {
        return _context?.AddListECs.Include(x => x.Person).ToList();
    }
}
