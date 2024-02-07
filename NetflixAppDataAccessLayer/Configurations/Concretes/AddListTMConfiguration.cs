using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDataAccessLayer.Configurations.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class AddListTMConfiguration : BaseAddListEntityConfiguration, IEntityTypeConfiguration<AddListTM>
{
    public void Configure(EntityTypeBuilder<AddListTM> builder)
    {
       builder.HasOne(p => p.Person)
            .WithMany(a => a.AddListTMs)
            .HasForeignKey(p => p.Id_Person)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Top250Movies)
            .WithMany(a => a.AddListTMs)
            .HasForeignKey(e => e.Id_TM)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
