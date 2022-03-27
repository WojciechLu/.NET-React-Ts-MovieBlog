using MovieBlog_Backend.Models.ModelsDTO;

namespace MovieBlog_Backend.Services.Interfaces
{
    public interface IReviewSrv
    {
        ReviewsDTO GetAllReviews();
        ResponseDTO AddReview(ReviewDTO review);
        ResponseDTO EditReview(ReviewDTO review);
        ResponseDTO DeleteReview(ReviewDTO review);
        ReviewsDTO GetReviewsByMovieDesc(int movieId);
        ReviewsDTO GetReviewsByUser(int userId);
    }
}
