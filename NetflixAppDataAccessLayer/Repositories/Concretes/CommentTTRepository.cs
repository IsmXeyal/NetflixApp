using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class CommentTTRepository : GenericRepository<CommentTT>, ICommentTTRepository
{
    public ICollection<CommentTT>? GetAllWithTop250TvShows()
    {
        return _context?.CommentTTs.Include(x => x.Top250TvShow).ToList();
    }
}
