using NetflixAppDomainLayer.Entities.Concretes;
using System.Linq.Expressions;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface IAddListMPMRepository : IGenericRepository<AddListMPM>
{
    ICollection<AddListMPM>? GetAllWithPerson();
    ICollection<AddListMPM>? GetAllWithMostPopularMovie();
}
