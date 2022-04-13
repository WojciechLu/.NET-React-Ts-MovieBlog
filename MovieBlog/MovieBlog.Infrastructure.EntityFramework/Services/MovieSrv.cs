using MovieBlog.Domain.Common.Models.ModelsDTO;
using MovieBlog.Domain.Interfaces.Infrastructure;

namespace MovieBlog.Infrastructure.EntityFramework;

public class MovieSrv : IMovieSrv
{
    private readonly ReviewDbContext context;
    public MovieSrv(ReviewDbContext context)
    {
        this.context = context;
    }

    public ResponseDTO AddMovie(MovieDTO movie)
    {
        if(movie != null)
        {
            var newMovie = context.Movies.FirstOrDefault(m => m.Id == movie.Id);
            var newMovie2 = context.Movies.FirstOrDefault(m => m.Title == movie.Title);
            if(newMovie == null && newMovie2 == null)
            {
                try
                {
                    var addMovie = new Movie()
                    {
                        Id = movie.Id,
                        Category = movie.Category,
                        Image = movie.Image,
                        Title = movie.Title,
                        MovieLists = new List<MovieList>(),
                        Reviews = new List<Review>()
                    };
                    context.Movies.Add(addMovie);
                    context.SaveChanges();

                    return new ResponseDTO { Code = 200, Message = "Added movie to db", Status = "Success" };
                }
                catch (Exception ex)
                {
                    return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Failed" };
                }
            }
            else return new ResponseDTO { Code = 400, Message = "Already exist", Status = "Failed" };
        }
        else return new ResponseDTO { Code = 400, Message = "Failed adding movie", Status = "Failed" };
    }

    public ResponseDTO DeleteMovie(MovieDTO movie)
    {
        if(movie != null)
        {
            var movieToDelete = context.Movies.FirstOrDefault(m => m.Id == movie.Id);
            if(movieToDelete != null)
            {
                try
                {
                    context.Movies.Remove(movieToDelete);
                    context.SaveChanges();
                    return new ResponseDTO { Code = 200, Message = "Deleted movie", Status = "Success" };
                }
                catch(Exception ex)
                {
                    return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Failed" };
                }
            }
            else return new ResponseDTO { Code = 400, Message = "Not found movie", Status = "Failed" };
        }
        else return new ResponseDTO { Code = 400, Message = "Failed deleting movie", Status = "Failed" };
    }

    public ResponseDTO EditMovie(MovieDTO movie)
    {
        if(movie != null)
        {
            var movieToEdit = context.Movies.FirstOrDefault(m => m.Id == movie.Id);
            if(movieToEdit != null)
            {
                try
                {
                    movieToEdit.Title = movie.Title;
                    movieToEdit.Category = movie.Category;
                    movieToEdit.Image = movie.Image;
                    context.SaveChanges();

                    return new ResponseDTO { Code = 200, Message = "Updated movie", Status = "Success" };
                }
                catch(Exception ex)
                {
                    return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Failed" };
                }
            }
            else return new ResponseDTO { Code = 400, Message = "Not found movie", Status = "Failed" };
        }
        else return new ResponseDTO { Code = 400, Message = "Failed editing movie", Status = "Failed" };
    }

    public MoviesDTO GetAllMovies()
    {
        var result = context.Movies.ToList();
        MoviesDTO movies = new MoviesDTO();
        movies.moviesList = new List<MovieDTO>();

        foreach (Movie movie in result)
        {
            var i = new MovieDTO { Id = movie.Id, Title = movie.Title, Category = movie.Category, Image = movie.Image };
            movies.moviesList.Add(i);
        }
        return movies;
    }

    public MovieDTO GetMovieByTitle(string title)
    {
        var findTitle = title.ToLower();
        var getMovie = context.Movies.FirstOrDefault(m => m.Title.ToLower() == findTitle);
        if(getMovie != null)
        {
            return new MovieDTO { Id = getMovie.Id, Title = getMovie.Title, Category = getMovie.Category, Image = getMovie.Image};
        }
        else return new MovieDTO { };
    }

    public MoviesDTO GetMoviesByCat(string category)
    {
        var result = context.Movies.ToList();
        MoviesDTO movies = new MoviesDTO();
        movies.moviesList = new List<MovieDTO>();

        foreach (Movie movie in result)
        {
            var findCategory = category.ToLower();
            if (movie.Category.ToLower() == findCategory)
            {
                var i = new MovieDTO { Id = movie.Id, Title = movie.Title, Category = movie.Category, Image = movie.Image };
                movies.moviesList.Add(i);
            }
        }
        return movies;
    }
    
}
