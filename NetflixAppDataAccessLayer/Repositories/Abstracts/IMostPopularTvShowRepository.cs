using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface IMostPopularTvShowRepository : IGenericRepository<MostPopularTvShow>
{
    ICollection<MostPopularTvShow>? GetAllWithGenres();
    ICollection<MostPopularTvShow>? GetAllWithAddListMpTs();
    ICollection<MostPopularTvShow>? GetAllWithLanguages();
    ICollection<MostPopularTvShow>? GetAllWithComments();
}
