using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
        builder.Property(x => x.Firstname).IsRequired();
        builder.Property(x => x.Lastname).IsRequired();
        builder.HasIndex(x => x.Username).IsUnique();
        builder.Property(x => x.Username).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Image).IsRequired().HasColumnType("nvarchar(max)");
        builder.Property(x => x.PhoneNumber).IsRequired();
    }
}
