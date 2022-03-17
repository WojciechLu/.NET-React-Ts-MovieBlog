using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieBlog_Backend.Models.ModelConfiguration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> entity)
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Assessment).IsRequired();
            entity.Property(r => r.Description).IsRequired();
            entity.HasOne<Movie>(m => m.RatedMovie)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.MovieId);
            entity.HasOne<User>(u => u.Author)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);
        }
    }
}
