using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class MostPopularMovieRepository : GenericRepository<MostPopularMovie>, IMostPopularMovieRepository
{
    public ICollection<MostPopularMovie>? GetAllWithAddListMPMs()
    {
        return _context?.MostPopularMovies.Include(x => x.AddListMPMs).ToList();
    }

    public ICollection<MostPopularMovie>? GetAllWithComments()
    {
        return _context?.MostPopularMovies.Include(x => x.Comments).ToList();
    }

    public ICollection<MostPopularMovie>? GetAllWithGenres()
    {
        return _context?.MostPopularMovies.Include(x => x.Genres).ToList();
    }

    public ICollection<MostPopularMovie>? GetAllWithLanguages()
    {
        return _context?.MostPopularMovies.Include(x => x.Languages).ToList();
    }
}
