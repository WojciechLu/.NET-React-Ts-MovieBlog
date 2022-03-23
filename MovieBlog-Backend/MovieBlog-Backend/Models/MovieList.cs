namespace MovieBlog_Backend.Models
{
    public class MovieList
    {
        public int ListId { get; set; }
        public ListToWatch List { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
