using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace blogpractice.Data.Configurations;

public class PostConfig: IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Content).IsRequired();

        builder.HasOne(p => p.Author)
            .WithMany(p => p.Posts)
            .HasForeignKey(f => f.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(e => e.Tags)
            .WithMany(e => e.Posts)
            .UsingEntity("PostTag");
    }
}