using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class Top250MovieRepository : GenericRepository<Top250Movie>, ITop250MovieRepository
{
    public ICollection<Top250Movie>? GetAllWithAddListTMs()
    {
        return _context?.Top250Movies.Include(x => x.AddListTMs).ToList();
    }

    public ICollection<Top250Movie>? GetAllWithComments()
    {
        return _context?.Top250Movies.Include(x => x.CommentTMs).ToList();
    }

    public ICollection<Top250Movie>? GetAllWithGenres()
    {
        return _context?.Top250Movies.Include(x => x.Genres).ToList();
    }

    public ICollection<Top250Movie>? GetAllWithLanguages()
    {
        return _context?.Top250Movies.Include(x => x.Languages).ToList();
    }
}
