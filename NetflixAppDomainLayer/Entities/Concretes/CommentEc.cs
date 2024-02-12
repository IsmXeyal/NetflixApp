using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class CommentEc : BaseCommentEntity
{
    // Foreign Key
    public int Id_EditorChoice { get; set; }

    // Navigation Property
    public virtual EditorChoice? EditorChoice { get; set; }
}
