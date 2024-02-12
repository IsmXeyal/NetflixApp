using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class CommentTT : BaseCommentEntity
{
    // Foreign Key
    public int Id_Top250TvShow { get; set; }

    // Navigation Property
    public virtual Top250TvShow? Top250TvShow { get; set; }
}
