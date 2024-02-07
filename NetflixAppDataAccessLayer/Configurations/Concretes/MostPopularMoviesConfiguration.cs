using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDataAccessLayer.Configurations.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class MostPopularMoviesConfiguration : BaseMovieTVEntityConfiguration, IEntityTypeConfiguration<MostPopularMovie>
{
    public void Configure(EntityTypeBuilder<MostPopularMovie> builder)
    {
        // No additional configurations needed for MostPopularMovie entity
    }
}
