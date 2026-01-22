using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace blogpractice.Data.Configurations;

public class CommentConfig: IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Body).IsRequired();
        builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        
        builder.HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(f => f.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}