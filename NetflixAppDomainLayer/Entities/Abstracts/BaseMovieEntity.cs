namespace NetflixAppDomainLayer.Entities.Abstracts;

public abstract class BaseMovieEntity : BaseServiceEntity
{
    public string? Imdb_link { get; set; }
    public decimal Imdb_rating { get; set; }
    public string? Image_link { get; set; }
    public string? Plot {  get; set; }
}
