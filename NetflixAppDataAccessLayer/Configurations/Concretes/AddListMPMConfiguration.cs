using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDataAccessLayer.Configurations.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class AddListMPMConfiguration : BaseAddListEntityConfiguration, IEntityTypeConfiguration<AddListMPM>
{
    public void Configure(EntityTypeBuilder<AddListMPM> builder)
    {
        builder.HasOne(p => p.Person)
            .WithMany(a => a.AddListMPMs)
            .HasForeignKey(p => p.Id_Person)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.MostPopularMovie)
            .WithMany(a => a.AddListMPMs)
            .HasForeignKey(e => e.Id_MPM)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
