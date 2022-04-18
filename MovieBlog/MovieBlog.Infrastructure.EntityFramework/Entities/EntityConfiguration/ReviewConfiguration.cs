using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieBlog.Infrastructure.EntityFramework.Entities.EntityConfiguration;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> entity)
    {
        entity.HasKey(r => r.Id);
        entity.Property(r => r.Assessment).IsRequired();
        entity.Property(r => r.Description).IsRequired();
        entity.HasOne(r => r.RatedMovie)
            .WithMany(m => m.Reviews)
            .HasForeignKey(r => r.MovieId);
        entity.HasOne(r => r.Author)
            .WithMany(a => a.Reviews)
            .HasForeignKey(r => new {r.AuthorId});
    }
}
