using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDataAccessLayer.Configurations.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class MostPopularTvShowConfiguration : BaseMovieTVEntityConfiguration, IEntityTypeConfiguration<MostPopularTvShow>
{
    public void Configure(EntityTypeBuilder<MostPopularTvShow> builder)
    {
        // No additional configurations needed for MostPopularTvShow entity
    }
}
