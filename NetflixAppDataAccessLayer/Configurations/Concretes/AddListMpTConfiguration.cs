using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class AddListMpTConfiguration : IEntityTypeConfiguration<AddListMpT>
{
    public void Configure(EntityTypeBuilder<AddListMpT> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
        builder.Property(e => e.IsFavorite).IsRequired();

        builder.HasOne(p => p.Person)
            .WithMany(a => a.AddListMpTs)
            .HasForeignKey(p => p.Id_Person)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.MostPopularTvShow)
            .WithMany(a => a.AddListMpTs)
            .HasForeignKey(e => e.Id_MpT)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
