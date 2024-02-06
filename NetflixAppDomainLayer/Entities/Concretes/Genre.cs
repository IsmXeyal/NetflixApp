using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class Genre : BaseServiceEntity
{
    // Navigation Property
    public virtual ICollection<EditorChoice>? EditorChoices { get; set; }
    public virtual ICollection<MostPopularMovie>? MostPopularMovies { get; set; }
    public virtual ICollection<MostPopularTvShow>? MostPopularTvShows { get; set; }
    public virtual ICollection<Top250Movie>? Top250Movies { get; set; }
    public virtual ICollection<Top250TvShow>? Top250TvShows { get; set; }
}
