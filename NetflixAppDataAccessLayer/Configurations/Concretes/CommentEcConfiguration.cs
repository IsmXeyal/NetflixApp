using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetflixAppDomainLayer.Entities.Concretes;

namespace NetflixAppDataAccessLayer.Configurations.Concretes;

internal class CommentEcConfiguration : IEntityTypeConfiguration<CommentEc>
{
    public void Configure(EntityTypeBuilder<CommentEc> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
        builder.Property(c => c.UserName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.CreatedDate).IsRequired().HasColumnType("datetime");
        builder.Property(c => c.Description).IsRequired();

        builder.HasOne(p => p.EditorChoice)
            .WithMany(a => a.CommentEcs)
            .HasForeignKey(p => p.Id_EditorChoice)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
