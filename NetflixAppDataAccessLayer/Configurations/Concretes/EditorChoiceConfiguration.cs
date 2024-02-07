using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDataAccessLayer.Configurations.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class EditorChoiceConfiguration : BaseMovieEntityConfiguration, IEntityTypeConfiguration<EditorChoice>
{
    public void Configure(EntityTypeBuilder<EditorChoice> builder)
    {
        builder.Property(x => x.Rank).IsRequired();
        builder.Property(x => x.Video_link).IsRequired();
    }
}
