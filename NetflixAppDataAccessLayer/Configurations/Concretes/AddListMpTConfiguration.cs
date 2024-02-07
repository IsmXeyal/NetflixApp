using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDataAccessLayer.Configurations.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class AddListMpTConfiguration : BaseAddListEntityConfiguration, IEntityTypeConfiguration<AddListMpT>
{
    public void Configure(EntityTypeBuilder<AddListMpT> builder)
    {
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
