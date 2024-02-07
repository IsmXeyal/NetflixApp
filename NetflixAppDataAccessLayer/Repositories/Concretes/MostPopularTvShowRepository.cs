using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class MostPopularTvShowRepository : GenericRepository<MostPopularTvShow>, IMostPopularTvShowRepository
{
    public ICollection<MostPopularTvShow>? GetAllWithAddListMpTs()
    {
        return _context?.MostPopularTvShows.Include(x => x.AddListMpTs).ToList();
    }

    public ICollection<MostPopularTvShow>? GetAllWithComments()
    {
        return _context?.MostPopularTvShows.Include(x => x.Comments).ToList();
    }

    public ICollection<MostPopularTvShow>? GetAllWithGenres()
    {
        return _context?.MostPopularTvShows.Include(x => x.Genres).ToList();
    }

    public ICollection<MostPopularTvShow>? GetAllWithLanguages()
    {
        return _context?.MostPopularTvShows.Include(x => x.Languages).ToList();
    }
}
