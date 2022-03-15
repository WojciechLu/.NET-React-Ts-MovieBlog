namespace MovieBlog_Backend.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public int Assessment { get; set; }
        public Movie RatedMovie { get; set; }
    }
}