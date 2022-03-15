using Microsoft.EntityFrameworkCore;

namespace MovieBlog_Backend.Entities
{
    public class ReviewDbContext: DbContext
    {
        private string _connectionString = "Server=localhost\\SQLEXPRESS;Database=MovieBlogDb;Trusted_Connection=True;";
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ListToWatch> ToWatch { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Title)
                .HasMaxLength(50);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
