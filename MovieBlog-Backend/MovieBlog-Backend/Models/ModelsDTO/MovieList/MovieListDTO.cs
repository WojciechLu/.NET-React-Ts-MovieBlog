namespace MovieBlog_Backend.Models.ModelsDTO
{
    public class MovieListDTO
    {
        public int ListId { get; set; }
        public ListToWatchDTO List { get; set; }
        public int MovieId { get; set; }
        public MovieDTO Movie { get; set; }
    }
}
