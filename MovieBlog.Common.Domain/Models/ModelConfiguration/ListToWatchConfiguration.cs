using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieBlog_Backend.Models.ModelConfiguration
{
    public class ListToWatchConfiguration : IEntityTypeConfiguration<ListToWatch>
    {
        public void Configure(EntityTypeBuilder<ListToWatch> entity)
        {
            entity.HasKey(l => l.Id);
            /*
            entity.HasMany(l => l.Movies)
                .WithMany(m => m.Lists);*/
/*            entity.HasOne(l => l.Owner)
                .WithOne(u => u.ToWatch)
                .HasForeignKey<User>(u => u.Id);
*/        }
    }
}
