using Microsoft.EntityFrameworkCore;
using NetflixAppDataAccessLayer.Repositories.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Concretes;

public class CommentMPMRepository : GenericRepository<CommentMPM>, ICommentMPMRepository
{
    public ICollection<CommentMPM>? GetAllWithMostPopularMovies()
    {
        return _context?.CommentMPMs.Include(x => x.MostPopularMovie).ToList();
    }
}
