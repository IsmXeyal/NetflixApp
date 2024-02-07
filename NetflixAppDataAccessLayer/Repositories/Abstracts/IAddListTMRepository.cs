using NetflixAppDomainLayer.Entities.Concretes;
using System.Linq.Expressions;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface IAddListTMRepository : IGenericRepository<AddListTM>
{
    ICollection<AddListTM>? GetAllWithPerson();
    ICollection<AddListTM>? GetAllWithTop250Movie();
}
