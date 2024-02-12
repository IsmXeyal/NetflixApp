using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class CommentMPM : BaseCommentEntity
{
    // Foreign Key
    public int Id_MostPopularMovie { get; set; }

    // Navigation Property
    public virtual MostPopularMovie? MostPopularMovie { get; set; }
}
