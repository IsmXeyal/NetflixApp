namespace NetflixAppDomainLayer.Entities.Abstracts;

public abstract class BaseAddListEntity : BaseEntity
{
    public bool IsFavorite { get; set; }

    public BaseAddListEntity() 
    {
        IsFavorite = false;
    }
}
