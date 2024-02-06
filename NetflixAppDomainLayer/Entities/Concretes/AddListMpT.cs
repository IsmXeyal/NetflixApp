using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class AddListMpT : BaseAddListEntity
{
    // Foreign Key
    public int Id_Person { get; set; }
    public int Id_MpT { get; set; }

    // Navigation Property
    public virtual Person? Person { get; set; }
    public virtual MostPopularTvShow? MostPopularTvShow { get; set; }
}
