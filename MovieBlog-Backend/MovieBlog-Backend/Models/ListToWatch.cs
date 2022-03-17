using MovieBlog_Backend.Entities;

namespace MovieBlog_Backend.Models
{
    public class ListToWatch
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public IList<Movie> Movies { get; set; }
        public User Owner { get; set; }
    }
}
