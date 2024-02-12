using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class Top250TvShowRepository : GenericRepository<Top250TvShow>, ITop250TvShowRepository
{
    public ICollection<Top250TvShow>? GetAllWithAddListTTs()
    {
        return _context?.Top250TvShows.Include(x => x.AddListTTs).ToList();
    }

    public ICollection<Top250TvShow>? GetAllWithComments()
    {
        return _context?.Top250TvShows.Include(x => x.CommentTTs).ToList();
    }

    public ICollection<Top250TvShow>? GetAllWithGenres()
    {
        return _context?.Top250TvShows.Include(x => x.Genres).ToList();
    }

    public ICollection<Top250TvShow>? GetAllWithLanguages()
    {
        return _context?.Top250TvShows.Include(x => x.Languages).ToList();
    }
}
