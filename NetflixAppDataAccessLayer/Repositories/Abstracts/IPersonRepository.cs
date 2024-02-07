using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface IPersonRepository : IGenericRepository<Person>
{
    ICollection<Person>? GetAllWithAddListECs();
    ICollection<Person>? GetAllWithAddListMPMs();
    ICollection<Person>? GetAllWithAddListMpTs();
    ICollection<Person>? GetAllWithAddListTMs();
    ICollection<Person>? GetAllWithAddListTTs();
}
