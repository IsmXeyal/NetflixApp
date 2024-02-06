using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class Person : BaseEntity
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Image { get; set; }
    public string? PhoneNumber { get; set; }

    public Person()
    {
        Image = null;
    }

    // Navigation Property
    public virtual ICollection<AddListEC>? AddListECs { get; set; }
    public virtual ICollection<MostPopularMovie>? MostPopularMovies { get; set; }
    public virtual ICollection<MostPopularTvShow>? MostPopularTvShows { get; set; }
    public virtual ICollection<Top250Movie>? Top250Movies { get; set; }
    public virtual ICollection<Top250TvShow>? Top250TvShows { get; set; }
}
