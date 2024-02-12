using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class CommentMPT : BaseCommentEntity
{
    // Foreign Key
    public int Id_MostPopularTvShow { get; set; }

    // Navigation Property
    public virtual MostPopularTvShow? MostPopularTvShow { get; set; }
}
