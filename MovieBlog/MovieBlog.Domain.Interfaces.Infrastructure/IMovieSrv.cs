using MovieBlog.Domain.Common.Models.ModelsDTO;

namespace MovieBlog.Domain.Interfaces.Infrastructure;

public interface IMovieSrv
{
    MoviesDTO GetAllMovies();
    MovieDTO GetMovieByTitle(string title);
    MoviesDTO GetMoviesByCat(string category);
    ResponseDTO AddMovie(MovieDTO movie);
    ResponseDTO EditMovie(MovieDTO movie);
    ResponseDTO DeleteMovie(MovieDTO movie);
}
