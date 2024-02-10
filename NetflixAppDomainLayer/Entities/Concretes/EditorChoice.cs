using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class EditorChoice : BaseMovieEntity
{
    public int Year { get; set; }
    public int Rank {  get; set; }
    public string? Video_link { get; set; }

    // Navigation Property
    public virtual ICollection<Genre>? Genres { get; set; }
    public virtual ICollection<AddListEC>? AddListECs { get; set; }
    public virtual ICollection<Language>? Languages { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
}
