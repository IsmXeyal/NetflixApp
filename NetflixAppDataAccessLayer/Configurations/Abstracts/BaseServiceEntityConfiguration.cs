using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Abstracts;

namespace NetflixAppDataAccessLayer.Configurations.Abstracts;

internal abstract class BaseServiceEntityConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<BaseServiceEntity>
{
    public void Configure(EntityTypeBuilder<BaseServiceEntity> builder)
    {
        builder.Property(x => x.Name).IsRequired();
    }
}
