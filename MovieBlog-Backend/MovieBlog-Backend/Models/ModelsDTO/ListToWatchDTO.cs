namespace MovieBlog_Backend.Models.ModelsDTO
{
    public class ListToWatchDTO
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public IList<Movie> Movies { get; set; }
    }
}
