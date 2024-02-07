using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class AddListMPMConfiguration : IEntityTypeConfiguration<AddListMPM>
{
    public void Configure(EntityTypeBuilder<AddListMPM> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
        builder.Property(e => e.IsFavorite).IsRequired();

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
