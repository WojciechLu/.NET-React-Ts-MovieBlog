using MovieBlog.Domain.Common.Models.ModelsDTO;
using MovieBlog.Domain.Interfaces.Facades;
using MovieBlog.Domain.Interfaces.Infrastructure;

namespace MovieBlog.Domain.Facades;

public class ReviewFcd : IReviewFcd
{
    private readonly IReviewSrv reviewSrv;
    public ReviewFcd(IReviewSrv reviewSrv)
    {
        this.reviewSrv = reviewSrv;
    }
    public ResponseDTO AddReview(ReviewDTO review)
    {
        return reviewSrv.AddReview(review);
    }

    public ResponseDTO DeleteReview(ReviewDTO review)
    {
        return reviewSrv.DeleteReview(review);
    }

    public ResponseDTO EditReview(ReviewDTO review)
    {
        return reviewSrv.EditReview(review);
    }

    public ReviewsDTO GetAllReviews()
    {
        return reviewSrv.GetAllReviews();
    }

    public ReviewsDTO GetReviewsByMovieDesc(int movieId)
    {
        return reviewSrv.GetReviewsByMovieDesc(movieId);
    }

    public ReviewsDTO GetReviewsByUser(int userId)
    {
        return reviewSrv.GetReviewsByUser(userId);
    }
}
