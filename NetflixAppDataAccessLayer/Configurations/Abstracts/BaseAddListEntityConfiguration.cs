using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDataAccessLayer.Configurations.Abstracts;

internal abstract class BaseAddListEntityConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<BaseAddListEntity>
{
    public void Configure(EntityTypeBuilder<BaseAddListEntity> builder)
    {
        builder.Property(e => e.IsFavorite).IsRequired();
    }
}
