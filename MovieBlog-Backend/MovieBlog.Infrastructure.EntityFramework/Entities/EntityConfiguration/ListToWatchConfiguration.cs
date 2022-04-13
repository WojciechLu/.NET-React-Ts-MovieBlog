using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieBlog.Infrastructure.EntityFramework
{
    public class ListToWatchConfiguration : IEntityTypeConfiguration<ListToWatch>
    {
        public void Configure(EntityTypeBuilder<ListToWatch> entity)
        {
            entity.HasKey(l => l.Id);
        }
    }
}
