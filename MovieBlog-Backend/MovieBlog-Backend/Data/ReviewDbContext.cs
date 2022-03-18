using Microsoft.EntityFrameworkCore;
using MovieBlog_Backend.Models;
using MovieBlog_Backend.Models.ModelConfiguration;

namespace MovieBlog_Backend.Data
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions<ReviewDbContext> options)
            : base(options)
        { }

        private string _connectionString = "Server=localhost\\SQLEXPRESS;Database=MovieBlogDb;Trusted_Connection=True;";
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ListToWatch> ToWatch { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ListToWatchConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
