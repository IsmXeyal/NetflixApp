using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDataAccessLayer.Configurations.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class Top250TvShowConfiguration : BaseMovieTVEntityConfiguration, IEntityTypeConfiguration<Top250TvShow>
{
    public void Configure(EntityTypeBuilder<Top250TvShow> builder)
    {
        // No additional configurations needed for Top250TvShow entity
    }
}
