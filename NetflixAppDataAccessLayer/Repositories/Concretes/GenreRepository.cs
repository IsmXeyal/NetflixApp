using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    public ICollection<Genre>? GetAllWithEditorChoices()
    {
        return _context?.Genres.Include(x => x.EditorChoices).ToList();
    }

    public ICollection<Genre>? GetAllWithMostPopularMovies()
    {
        return _context?.Genres.Include(x => x.MostPopularMovies).ToList();
    }

    public ICollection<Genre>? GetAllWithMostPopularTvShows()
    {
        return _context?.Genres.Include(x => x.MostPopularTvShows).ToList();
    }

    public ICollection<Genre>? GetAllWithTop250Movies()
    {
        return _context?.Genres.Include(x => x.Top250Movies).ToList();
    }

    public ICollection<Genre>? GetAllWithTop250TvShows()
    {
        return _context?.Genres.Include(x => x.Top250TvShows).ToList();
    }
}
