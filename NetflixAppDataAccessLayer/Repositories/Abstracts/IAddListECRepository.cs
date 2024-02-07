using NetflixAppDomainLayer.Entities.Concretes;
using System.Linq.Expressions;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface IAddListECRepository : IGenericRepository<AddListEC>
{
    ICollection<AddListEC>? GetAllWithPerson();
    ICollection<AddListEC>? GetAllWithEditorChoice();
}
