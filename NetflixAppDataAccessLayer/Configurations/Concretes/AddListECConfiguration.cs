using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDataAccessLayer.Configurations.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class AddListECConfiguration : BaseAddListEntityConfiguration, IEntityTypeConfiguration<AddListEC>
{
    public void Configure(EntityTypeBuilder<AddListEC> builder)
    {
        builder.HasOne(p => p.Person)
            .WithMany(a => a.AddListECs)
            .HasForeignKey(p => p.Id_Person)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.EditorChoice)
            .WithMany(a => a.AddListECs)
            .HasForeignKey(e => e.Id_ECMovie)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
