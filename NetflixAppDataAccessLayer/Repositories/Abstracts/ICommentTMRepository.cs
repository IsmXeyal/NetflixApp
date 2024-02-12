using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface ICommentTMRepository : IGenericRepository<CommentTM>
{
    ICollection<CommentTM>? GetAllWithTop250Movies();
}
