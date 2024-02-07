using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface IGenreRepository : IGenericRepository<Genre>
{
    ICollection<Genre>? GetAllWithEditorChoices();
    ICollection<Genre>? GetAllWithMostPopularMovies();
    ICollection<Genre>? GetAllWithMostPopularTvShows();
    ICollection<Genre>? GetAllWithTop250Movies();
    ICollection<Genre>? GetAllWithTop250TvShows();
}
