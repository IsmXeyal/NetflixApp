namespace NetflixAppDomainLayer.Entities.Abstracts;

public abstract class BaseMovieTVEntity : BaseMovieEntity
{
    public string? Year { get; set; }
    public string? Duration { get; set; }
}
