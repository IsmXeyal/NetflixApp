using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface IMostPopularMovieRepository : IGenericRepository<MostPopularMovie>
{
    ICollection<MostPopularMovie>? GetAllWithGenres();
    ICollection<MostPopularMovie>? GetAllWithAddListMPMs();
    ICollection<MostPopularMovie>? GetAllWithLanguages();
    ICollection<MostPopularMovie>? GetAllWithComments();
}
