using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace blogpractice.Data.Configurations;

public class AuthorConfig : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Email).HasMaxLength(1000);
    }
}