using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class CommentTM : BaseCommentEntity
{
    // Foreign Key
    public int Id_Top250Movie { get; set; }

    // Navigation Property
    public virtual Top250Movie? Top250Movie { get; set; }
}
