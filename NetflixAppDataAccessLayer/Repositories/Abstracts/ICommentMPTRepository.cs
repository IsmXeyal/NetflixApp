using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface ICommentMPTRepository : IGenericRepository<CommentMPT>
{
    ICollection<CommentMPT>? GetAllWithMostPopularTvShows();
}
