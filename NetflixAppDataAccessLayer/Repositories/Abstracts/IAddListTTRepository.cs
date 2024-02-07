using NetflixAppDomainLayer.Entities.Concretes;
using System.Linq.Expressions;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface IAddListTTRepository : IGenericRepository<AddListTT>
{
    ICollection<AddListTT>? GetAllWithPerson();
    ICollection<AddListTT>? GetAllWithTop250Movie();
}
