using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface ILanguageRepository : IGenericRepository<Language>
{
    ICollection<Language>? GetAllWithEditorChoices();
    ICollection<Language>? GetAllWithMostPopularMovies();
    ICollection<Language>? GetAllWithMostPopularTvShows();
    ICollection<Language>? GetAllWithTop250Movies();
    ICollection<Language>? GetAllWithTop250TvShows();
}
