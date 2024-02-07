using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class AddListECConfiguration : IEntityTypeConfiguration<AddListEC>
{
    public void Configure(EntityTypeBuilder<AddListEC> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
        builder.Property(e => e.IsFavorite).IsRequired();

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
