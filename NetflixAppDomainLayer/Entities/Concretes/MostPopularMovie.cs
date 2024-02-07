using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class MostPopularMovie : BaseMovieTVEntity
{
    // Navigation Property
    public virtual ICollection<Genre>? Genres { get; set; }
    public virtual ICollection<AddListMPM>? AddListMPMs { get; set; }
    public virtual ICollection<Language>? Languages { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
}
