namespace NetflixAppDomainLayer.Entities.Abstracts;

public abstract class BaseCommentEntity : BaseEntity
{
    public string? UserName { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? Description { get; set; }

    public BaseCommentEntity() 
    {
        CreatedDate = DateTime.Now;
    }
}
