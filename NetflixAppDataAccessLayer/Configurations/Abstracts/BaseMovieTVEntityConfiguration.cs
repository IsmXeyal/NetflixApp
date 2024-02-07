using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDataAccessLayer.Configurations.Abstracts;

internal abstract class BaseMovieTVEntityConfiguration : BaseMovieEntityConfiguration, IEntityTypeConfiguration<BaseMovieTVEntity>
{
    public void Configure(EntityTypeBuilder<BaseMovieTVEntity> builder)
    {
        builder.Property(x => x.Duration).IsRequired();
    }
}
