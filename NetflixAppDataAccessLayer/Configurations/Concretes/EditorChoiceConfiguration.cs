using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class EditorChoiceConfiguration : IEntityTypeConfiguration<EditorChoice>
{
    public void Configure(EntityTypeBuilder<EditorChoice> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Imdb_link).IsRequired();
        builder.Property(x => x.Year).IsRequired();
        builder.Property(x => x.Imdb_rating).IsRequired().HasColumnType("decimal(3,1)");
        builder.Property(x => x.Image_link).IsRequired();
        builder.Property(x => x.Plot).IsRequired();
        builder.Property(x => x.Rank).IsRequired();
        builder.Property(x => x.Video_link).IsRequired();
    }
}
