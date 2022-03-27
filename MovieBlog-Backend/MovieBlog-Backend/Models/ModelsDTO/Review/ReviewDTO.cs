namespace MovieBlog_Backend.Models.ModelsDTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int MovieId { get; set; }
        public string Description { get; set; }
        public int Assessment { get; set; }
    }
}
