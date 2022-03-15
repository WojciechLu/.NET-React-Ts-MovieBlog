namespace MovieBlog_Backend.Entities
{
    public class ListToWatch
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Movie> Movies { get; set; }
    }
}