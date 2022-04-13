using MovieBlog.Domain.Common.Models.ModelsDTO;

namespace MovieBlog.Domain.Interfaces.Facades;

public interface IReviewFcd
{
    ReviewsDTO GetAllReviews();
    ResponseDTO AddReview(ReviewDTO review);
    ResponseDTO EditReview(ReviewDTO review);
    ResponseDTO DeleteReview(ReviewDTO review);
    ReviewsDTO GetReviewsByMovieDesc(int movieId);
    ReviewsDTO GetReviewsByUser(int userId);
}
