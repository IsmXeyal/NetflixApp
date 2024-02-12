using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class CommentMPTConfiguration : IEntityTypeConfiguration<CommentMPT>
{
    public void Configure(EntityTypeBuilder<CommentMPT> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
        builder.Property(c => c.UserName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.CreatedDate).IsRequired().HasColumnType("datetime");
        builder.Property(c => c.Description).IsRequired();

        builder.HasOne(p => p.MostPopularTvShow)
            .WithMany(a => a.CommentMPTs)
            .HasForeignKey(p => p.Id_MostPopularTvShow)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
