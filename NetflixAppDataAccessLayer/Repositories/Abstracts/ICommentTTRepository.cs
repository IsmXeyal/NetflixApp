using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface ICommentTTRepository : IGenericRepository<CommentTT>
{
    ICollection<CommentTT>? GetAllWithTop250TvShows();
}
