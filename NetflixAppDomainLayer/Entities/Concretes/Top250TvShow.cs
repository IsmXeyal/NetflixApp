using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class Top250TvShow : BaseMovieTVEntity
{
    // Navigation Property
    public virtual ICollection<Genre>? Genres { get; set; }
    public virtual ICollection<AddListTT>? AddListTTs { get; set; }
    public virtual ICollection<Language>? Languages { get; set; }
}
