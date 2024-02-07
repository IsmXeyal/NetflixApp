using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class MostPopularTvShow : BaseMovieTVEntity
{
    // Navigation Property
    public virtual ICollection<Genre>? Genres { get; set; }
    public virtual ICollection<AddListMpT>? AddListMpTs { get; set; }
    public virtual ICollection<Language>? Languages { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
}
