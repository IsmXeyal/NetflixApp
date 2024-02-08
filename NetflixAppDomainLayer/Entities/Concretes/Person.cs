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

    // Navigation Property
    public virtual ICollection<AddListEC>? AddListECs { get; set; }
    public virtual ICollection<AddListMPM>? AddListMPMs { get; set; }
    public virtual ICollection<AddListMpT>? AddListMpTs { get; set; }
    public virtual ICollection<AddListTM>? AddListTMs { get; set; }
    public virtual ICollection<AddListTT>? AddListTTs { get; set; }
}
