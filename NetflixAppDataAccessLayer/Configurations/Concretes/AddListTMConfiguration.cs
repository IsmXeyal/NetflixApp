using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class AddListTMConfiguration : IEntityTypeConfiguration<AddListTM>
{
    public void Configure(EntityTypeBuilder<AddListTM> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
        builder.Property(e => e.IsFavorite).IsRequired();

        builder.HasOne(p => p.Person)
            .WithMany(a => a.AddListTMs)
            .HasForeignKey(p => p.Id_Person)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Top250Movie)
            .WithMany(a => a.AddListTMs)
            .HasForeignKey(e => e.Id_TM)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
