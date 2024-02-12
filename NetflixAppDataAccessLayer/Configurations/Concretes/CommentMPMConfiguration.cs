using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class CommentMPMConfiguration : IEntityTypeConfiguration<CommentMPM>
{
    public void Configure(EntityTypeBuilder<CommentMPM> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
        builder.Property(c => c.UserName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.CreatedDate).IsRequired().HasColumnType("datetime");
        builder.Property(c => c.Description).IsRequired();

        builder.HasOne(p => p.MostPopularMovie)
            .WithMany(a => a.CommentMPMs)
            .HasForeignKey(p => p.Id_MostPopularMovie)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
