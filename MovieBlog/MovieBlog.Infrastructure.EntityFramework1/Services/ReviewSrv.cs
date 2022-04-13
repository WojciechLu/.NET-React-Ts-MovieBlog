using MovieBlog_Backend.Data;
using MovieBlog_Backend.Models;
using MovieBlog_Backend.Models.ModelsDTO;
using MovieBlog_Backend.Services.Interfaces;

namespace MovieBlog.Infrastructure.EntityFramework
{
    public class ReviewSrv : IReviewSrv
    {
        private readonly ReviewDbContext context;
        public ReviewSrv(ReviewDbContext context)
        {
            this.context = context;
        }

        public ResponseDTO AddReview(ReviewDTO review)
        {
            if (review != null)
            {
                try
                {
                    var reviewedMovie = context.Movies.FirstOrDefault(m => m.Id == review.MovieId);
                    if (reviewedMovie != null)
                    {
                        var movieReviews = reviewedMovie.Reviews.ToList();
                        if(movieReviews == null)
                        {
                            reviewedMovie.Reviews = new List<Review>();
                        }
                        else
                        {
                            foreach (var item in movieReviews)
                            {
                                if (item.AuthorId == review.AuthorId)
                                {
                                    return new ResponseDTO() { Code = 400, Message = "Review already exist for this movie", Status = "Failed" };
                                }
                            }
                        }

                        var newReview = new Review()
                        {
                            Id = review.Id,
                            AuthorId = review.AuthorId,
                            MovieId = review.MovieId,
                            Assessment = review.Assessment,
                            Description = review.Description
                        };

                        context.Reviews.Add(newReview);
                        reviewedMovie.Reviews.Add(newReview);

                        context.SaveChanges();
                        return new ResponseDTO() { Code = 200, Message = "Added review to movie", Status = "Success" };
                    }
                    else return new ResponseDTO() { Code = 400, Message = "Movie doesnt exist", Status = "Failed" };
                }
                catch(Exception ex)
                {
                    return new ResponseDTO() { Code = 400, Message = ex.Message, Status = "Failed" };
                }
            }
            else return new ResponseDTO() { Code = 400, Message = "Review is null", Status = "Failed" };
        }

        public ResponseDTO DeleteReview(ReviewDTO review)
        {
            if(review != null)
            {
                var reviewToRemove = context.Reviews.FirstOrDefault(r => r.Id == review.Id);
                if (reviewToRemove != null)
                {
                    try
                    {
                        var reviewedMovie = context.Movies.FirstOrDefault(m => m.Id == review.MovieId);
                        var author = context.Users.FirstOrDefault(u => u.Id == review.AuthorId);

                        reviewedMovie.Reviews.Remove(reviewToRemove);
                        author.Reviews.Remove(reviewToRemove);
                        context.Reviews.Remove(reviewToRemove);
                        context.SaveChanges();

                        return new ResponseDTO() { Code = 200, Message = "Removed review", Status = "Success" };
                    }
                    catch(Exception ex)
                    {
                        return new ResponseDTO() { Code = 400, Message = ex.Message, Status = "Failed" };
                    }
                }
                else return new ResponseDTO() { Code = 400, Message = "Not found review to remove", Status = "Failed" };
            }
            return new ResponseDTO() { Code = 400, Message = "Review to remove is null", Status = "Failed" };
        }

        public ResponseDTO EditReview(ReviewDTO review)
        {
            if (review != null)
            {
                try
                {
                    var reviewToEdit = context.Reviews.FirstOrDefault(r => r.Id == review.Id);
                    if (reviewToEdit != null)
                    {
                        reviewToEdit.Assessment = review.Assessment;
                        reviewToEdit.Description = review.Description;

                        context.SaveChanges();
                        return new ResponseDTO() { Code = 200, Message = "Edited review", Status = "Success" };
                    }
                    else return new ResponseDTO() { Code = 400, Message = "Not found review to edit", Status = "Failed" };
                }
                catch (Exception ex)
                {
                    return new ResponseDTO() { Code = 400, Message = ex.Message, Status = "Failed" };
                }
            }
            else return new ResponseDTO() { Code = 400, Message = "Review to edit is null", Status = "Failed" };
        }

        public ReviewsDTO GetAllReviews()
        {
            var result = context.Reviews.ToList();
            ReviewsDTO reviews = new ReviewsDTO();
            reviews.reviewList = new List<ReviewDTO>();

            foreach (Review review in result)
            {
                var i = new ReviewDTO { Id = review.Id, Assessment = review.Assessment, AuthorId = review.AuthorId, Description = review.Description, MovieId = review.MovieId };
                reviews.reviewList.Add(i);
            }
            return reviews;
        }

        public ReviewsDTO GetReviewsByMovieDesc(int movieId)
        {
            var result = context.Reviews.ToList();
            ReviewsDTO reviews = new ReviewsDTO();
            reviews.reviewList = new List<ReviewDTO>();

            for (int i = 5; i >= 1; i--)
            {
                foreach (Review review in result)
                {
                    if (review.MovieId == movieId)
                    {
                        if(review.Assessment == i)
                        {
                            var j = new ReviewDTO { Id = review.Id, Assessment = review.Assessment, AuthorId = review.AuthorId, Description = review.Description, MovieId = review.MovieId };
                            reviews.reviewList.Add(j);
                        }
                    }
                }
            }
            return reviews;
        }

        public ReviewsDTO GetReviewsByUser(int userId)
        {
            var result = context.Reviews.ToList();
            ReviewsDTO reviews = new ReviewsDTO();
            reviews.reviewList = new List<ReviewDTO>();

            for (int i = 5; i >= 1; i--)
            {
                foreach (Review review in result)
                {
                    if (review.AuthorId == userId)
                    {
                        if (review.Assessment == i)
                        {
                            var j = new ReviewDTO { Id = review.Id, Assessment = review.Assessment, AuthorId = review.AuthorId, Description = review.Description, MovieId = review.MovieId };
                            reviews.reviewList.Add(j);
                        }
                    }
                }
            }
            return reviews;
        }
    }
}
