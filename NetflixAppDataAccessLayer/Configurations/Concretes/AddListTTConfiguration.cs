using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDataAccessLayer.Configurations.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class AddListTTConfiguration : BaseAddListEntityConfiguration, IEntityTypeConfiguration<AddListTT>
{
    public void Configure(EntityTypeBuilder<AddListTT> builder)
    {
       builder.HasOne(p => p.Person)
            .WithMany(a => a.AddListTTs)
            .HasForeignKey(p => p.Id_Person)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Top250TvShows)
            .WithMany(a => a.AddListTTs)
            .HasForeignKey(e => e.Id_TT)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
