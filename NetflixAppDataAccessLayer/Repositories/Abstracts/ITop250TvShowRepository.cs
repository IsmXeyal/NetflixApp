using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface ITop250TvShowRepository : IGenericRepository<Top250TvShow>
{
    ICollection<Top250TvShow>? GetAllWithGenres();
    ICollection<Top250TvShow>? GetAllWithAddListTTs();
    ICollection<Top250TvShow>? GetAllWithLanguages();
    ICollection<Top250TvShow>? GetAllWithComments();
}
