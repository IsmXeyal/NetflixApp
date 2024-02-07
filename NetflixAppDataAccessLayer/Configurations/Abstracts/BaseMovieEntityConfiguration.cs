using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDataAccessLayer.Configurations.Abstracts;

internal abstract class BaseMovieEntityConfiguration : BaseServiceEntityConfiguration, IEntityTypeConfiguration<BaseMovieEntity>
{
    public void Configure(EntityTypeBuilder<BaseMovieEntity> builder)
    {
        builder.Property(x => x.Imdb_link).IsRequired();
        builder.Property(x => x.Year).IsRequired();
        builder.Property(x => x.Imdb_rating).IsRequired();
        builder.Property(x => x.Image_link).IsRequired();
        builder.Property(x => x.Plot).IsRequired();
    }
}
