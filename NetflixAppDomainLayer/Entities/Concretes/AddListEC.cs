using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDomainLayer.Entities.Concretes;

public class AddListEC : BaseAddListEntity
{
    // Foreign Key
    public int Id_Person { get; set; }
    public int Id_ECMovie { get; set; }

    // Navigation Property
    public virtual Person? Person { get; set; }
    public virtual EditorChoice? EditorChoice { get; set; }
}
