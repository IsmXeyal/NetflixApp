using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class CommentMPTRepository : GenericRepository<CommentMPT>, ICommentMPTRepository
{
    public ICollection<CommentMPT>? GetAllWithMostPopularTvShows()
    {
        return _context?.CommentMPTs.Include(x => x.MostPopularTvShow).ToList();
    }
}
