using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class AddListMPM : BaseAddListEntity
{
    // Foreign Key
    public int Id_Person { get; set; }
    public int Id_MPM { get; set; }

    // Navigation Property
    public virtual Person? Person { get; set; }
    public virtual MostPopularMovie? MostPopularMovie { get; set; }
}
