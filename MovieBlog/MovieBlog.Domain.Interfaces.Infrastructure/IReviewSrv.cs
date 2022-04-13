using MovieBlog.Domain.Common.Models.ModelsDTO;


namespace MovieBlog.Domain.Interfaces.Infrastructure;

public interface IReviewSrv
{
    ReviewsDTO GetAllReviews();
    ResponseDTO AddReview(ReviewDTO review);
    ResponseDTO EditReview(ReviewDTO review);
    ResponseDTO DeleteReview(ReviewDTO review);
    ReviewsDTO GetReviewsByMovieDesc(int movieId);
    ReviewsDTO GetReviewsByUser(int userId);
}
