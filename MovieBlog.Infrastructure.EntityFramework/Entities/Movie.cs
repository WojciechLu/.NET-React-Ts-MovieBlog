namespace MovieBlog.Infrastructure.EntityFramework
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public IList<Review> Reviews { get; set; }
        public IList<MovieList> MovieLists { get; set; }
    }
}
