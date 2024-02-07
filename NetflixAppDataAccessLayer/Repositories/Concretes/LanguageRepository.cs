using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
{
    public ICollection<Language>? GetAllWithEditorChoices()
    {
        return _context?.Languages.Include(x => x.EditorChoices).ToList();
    }

    public ICollection<Language>? GetAllWithMostPopularMovies()
    {
        return _context?.Languages.Include(x => x.MostPopularMovies).ToList();
    }

    public ICollection<Language>? GetAllWithMostPopularTvShows()
    {
        return _context?.Languages.Include(x => x.MostPopularTvShows).ToList();
    }

    public ICollection<Language>? GetAllWithTop250Movies()
    {
        return _context?.Languages.Include(x => x.Top250Movies).ToList();
    }

    public ICollection<Language>? GetAllWithTop250TvShows()
    {
        return _context?.Languages.Include(x => x.Top250TvShows).ToList();
    }
}
