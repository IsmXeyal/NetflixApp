using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class MostPopularMovie : BaseMovieTVEntity
{
    // Navigation Property
    public virtual ICollection<Genre>? Genres { get; set; }
    public virtual ICollection<MostPopularMovie>? MostPopularMovies { get; set; }
    public virtual ICollection<Language>? Languages { get; set; }
}
