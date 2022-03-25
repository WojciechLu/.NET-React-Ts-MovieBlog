namespace MovieBlog_Backend.Models.ModelsDTO
{
    public class ListToWatchDTO
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public IList<MovieList> MoviesList { get; set; }
    }
}
