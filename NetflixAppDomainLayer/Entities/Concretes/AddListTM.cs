using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class AddListTM : BaseAddListEntity
{
    // Foreign Key
    public int Id_Person { get; set; }
    public int Id_TM { get; set; }

    // Navigation Property
    public virtual Person? Person { get; set; }
    public virtual Top250Movie? Top250Movies { get; set; }
}
