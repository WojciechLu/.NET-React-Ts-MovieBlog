using MovieBlog.Domain.Common.Models.ModelsDTO;
using MovieBlog.Domain.Interfaces.Facades;
using MovieBlog.Domain.Interfaces.Infrastructure;

namespace MovieBlog.Domain.Facades;

public class MovieFcd : IMovieFcd
{
    private readonly IMovieSrv movieSrv;
    public MovieFcd(IMovieSrv movieSrv)
    {
        this.movieSrv = movieSrv;
    }
    public ResponseDTO AddMovie(MovieDTO movie)
    {
        return movieSrv.AddMovie(movie);
    }

    public ResponseDTO DeleteMovie(MovieDTO movie)
    {
        return movieSrv.DeleteMovie(movie);
    }

    public ResponseDTO EditMovie(MovieDTO movie)
    {
        return movieSrv.EditMovie(movie);
    }

    public MoviesDTO GetAllMovies()
    {
        return movieSrv.GetAllMovies();
    }

    public MovieDTO GetMovieByTitle(string title)
    {
        return movieSrv.GetMovieByTitle(title);
    }

    public MoviesDTO GetMoviesByCat(string category)
    {
        return movieSrv.GetMoviesByCat(category);
    }
}
