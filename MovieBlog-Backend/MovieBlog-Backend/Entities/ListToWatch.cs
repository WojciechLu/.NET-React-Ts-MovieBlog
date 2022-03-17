namespace MovieBlog_Backend.Entities
{
    public class ListToWatch
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public List<Movie> Movies { get; set; }
        public User Owner { get; set; }
    }
}