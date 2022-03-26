namespace MovieBlog_Backend.Models.ModelsDTO.Review
{
    public class AddReviewDTO
    {
        public int AuthorId { get; set; }
        public int MovieId { get; set; }
        public string Description { get; set; }
        public int Assessment { get; set; }
    }
}
