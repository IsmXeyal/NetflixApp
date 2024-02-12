using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class CommentTMRepository : GenericRepository<CommentTM>, ICommentTMRepository
{
    public ICollection<CommentTM>? GetAllWithTop250Movies()
    {
        return _context?.CommentTMs.Include(x => x.Top250Movie).ToList();
    }
}
