using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class AddListTT : BaseAddListEntity
{
    // Foreign Key
    public int Id_Person { get; set; }
    public int Id_TT { get; set; }

    // Navigation Property
    public virtual Person? Person { get; set; }
    public virtual Top250TvShow? Top250TvShows { get; set; }
}
