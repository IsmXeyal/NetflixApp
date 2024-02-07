using NetflixAppDomainLayer.Entities.Concretes;
using System.Linq.Expressions;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface IAddListMpTRepository : IGenericRepository<AddListMpT>
{
    ICollection<AddListMpT>? GetAllWithPerson();
    ICollection<AddListMpT>? GetAllWithMostPopularTvShow();
}
