using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class Top250Movie : BaseMovieTVEntity
{
    // Navigation Property
    public virtual ICollection<Genre>? Genres { get; set; }
    public virtual ICollection<AddListTM>? AddListTMs { get; set; }
    public virtual ICollection<Language>? Languages { get; set; }
    public virtual ICollection<CommentTM>? CommentTMs { get; set; }
}
