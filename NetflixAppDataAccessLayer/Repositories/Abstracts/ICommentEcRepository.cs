using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Repositories.Abstracts;

public interface ICommentEcRepository : IGenericRepository<CommentEc>
{
    ICollection<CommentEc>? GetAllWithEditorChoices();
}
