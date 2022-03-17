using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieBlog_Backend.Models.ModelConfiguration
{
    public class ListToWatchConfiguration : IEntityTypeConfiguration<ListToWatch>
    {
        public void Configure(EntityTypeBuilder<ListToWatch> entity)
        {
            entity.HasKey(l => l.Id);
            entity.HasOne(l => l.Owner)
                .WithOne(o => o.ToWatch)
                .HasForeignKey<User>(l => l.IdListToWatch);
        }
    }
}
