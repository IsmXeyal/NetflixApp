using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDataAccessLayer.Configurations.Abstracts;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class Top250MovieConfiguration : BaseMovieTVEntityConfiguration, IEntityTypeConfiguration<Top250Movie>
{
    public void Configure(EntityTypeBuilder<Top250Movie> builder)
    {
        // No additional configurations needed for Top250Movie entity
    }
}
