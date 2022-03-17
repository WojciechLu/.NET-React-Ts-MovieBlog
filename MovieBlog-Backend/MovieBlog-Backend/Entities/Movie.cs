namespace MovieBlog_Backend.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public IList<Review> Reviews { get; set; }
    }
}
