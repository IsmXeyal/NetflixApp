using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class CommentTMConfiguration : IEntityTypeConfiguration<CommentTM>
{
    public void Configure(EntityTypeBuilder<CommentTM> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
        builder.Property(c => c.UserName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.CreatedDate).IsRequired().HasColumnType("datetime");
        builder.Property(c => c.Description).IsRequired();

        builder.HasOne(p => p.Top250Movie)
            .WithMany(a => a.CommentTMs)
            .HasForeignKey(p => p.Id_Top250Movie)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
