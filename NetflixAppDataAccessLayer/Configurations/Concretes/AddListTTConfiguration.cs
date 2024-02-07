using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class AddListTTConfiguration : IEntityTypeConfiguration<AddListTT>
{
    public void Configure(EntityTypeBuilder<AddListTT> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
        builder.Property(e => e.IsFavorite).IsRequired();

        builder.HasOne(p => p.Person)
            .WithMany(a => a.AddListTTs)
            .HasForeignKey(p => p.Id_Person)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Top250TvShow)
            .WithMany(a => a.AddListTTs)
            .HasForeignKey(e => e.Id_TT)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
