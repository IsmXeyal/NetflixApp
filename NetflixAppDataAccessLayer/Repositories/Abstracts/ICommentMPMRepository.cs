using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface ICommentMPMRepository : IGenericRepository<CommentMPM>
{
    ICollection<CommentMPM>? GetAllWithMostPopularMovies();
}
