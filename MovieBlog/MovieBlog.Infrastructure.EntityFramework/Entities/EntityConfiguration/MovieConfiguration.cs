using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieBlog.Infrastructure.EntityFramework
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> entity)
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Title).IsRequired();
            entity.Property(m => m.Category).IsRequired();
        }
    }
}
