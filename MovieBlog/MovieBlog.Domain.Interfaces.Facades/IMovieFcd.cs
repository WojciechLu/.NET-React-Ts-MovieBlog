using MovieBlog.Domain.Common.Models.ModelsDTO;

namespace MovieBlog.Domain.Interfaces.Facades;

public interface IMovieFcd
{
    MoviesDTO GetAllMovies();
    MovieDTO GetMovieByTitle(string title);
    MoviesDTO GetMoviesByCat(string category);
    ResponseDTO AddMovie(MovieDTO movie);
    ResponseDTO EditMovie(MovieDTO movie);
    ResponseDTO DeleteMovie(MovieDTO movie);
}
