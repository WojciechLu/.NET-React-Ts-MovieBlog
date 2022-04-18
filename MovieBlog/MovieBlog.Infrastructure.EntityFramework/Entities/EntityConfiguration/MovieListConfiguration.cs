using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieBlog.Infrastructure.EntityFramework.Entities.EntityConfiguration;

public class MovieListConfiguration : IEntityTypeConfiguration<MovieList>
{
    public void Configure(EntityTypeBuilder<MovieList> entity)
    {
        entity.HasKey(ml => new { ml.MovieId, ml.ListId });
        entity.HasOne(ml => ml.Movie)
            .WithMany(m => m.MovieLists)
            .HasForeignKey(ml => ml.MovieId);
        entity.HasOne(ml => ml.List)
            .WithMany(l => l.MoviesLists)
            .HasForeignKey(ml => ml.ListId);
    }
}
