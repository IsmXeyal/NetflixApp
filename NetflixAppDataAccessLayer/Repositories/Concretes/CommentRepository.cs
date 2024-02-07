using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public ICollection<Comment>? GetAllWithEditorChoices()
    {
        return _context?.Comments.Include(x => x.EditorChoices).ToList();
    }

    public ICollection<Comment>? GetAllWithMostPopularMovies()
    {
        return _context?.Comments.Include(x => x.MostPopularMovies).ToList();
    }

    public ICollection<Comment>? GetAllWithMostPopularTvShows()
    {
        return _context?.Comments.Include(x => x.MostPopularTvShows).ToList();
    }

    public ICollection<Comment>? GetAllWithTop250Movies()
    {
        return _context?.Comments.Include(x => x.Top250Movies).ToList();
    }

    public ICollection<Comment>? GetAllWithTop250TvShows()
    {
        return _context?.Comments.Include(x => x.Top250TvShows).ToList();
    }
}
