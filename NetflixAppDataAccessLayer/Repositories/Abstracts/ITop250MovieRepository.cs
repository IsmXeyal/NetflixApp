using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface ITop250MovieRepository : IGenericRepository<Top250Movie>
{
    ICollection<Top250Movie>? GetAllWithGenres();
    ICollection<Top250Movie>? GetAllWithAddListTMs();
    ICollection<Top250Movie>? GetAllWithLanguages();
    ICollection<Top250Movie>? GetAllWithComments();
}
