using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class MostPopularTvShowConfiguration : IEntityTypeConfiguration<MostPopularTvShow>
{
    public void Configure(EntityTypeBuilder<MostPopularTvShow> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Imdb_link).IsRequired();
        builder.Property(x => x.Year).IsRequired().HasColumnType("nvarchar(max)");
        builder.Property(x => x.Duration).IsRequired();
        builder.Property(x => x.Imdb_rating).IsRequired().HasColumnType("decimal(3,1)");
        builder.Property(x => x.Image_link).IsRequired();
        builder.Property(x => x.Plot).IsRequired();
    }
}
