using MovieBlog_Backend.Models.ModelsDTO;

namespace MovieBlog_Backend.Services.Interfaces
{
    public interface IMovieSrv
    {
        MoviesDTO GetAllMovies();
        MovieDTO GetMovieByTitle(string title);
        MoviesDTO GetMoviesByCat(string category);
        ResponseDTO AddMovie(MovieDTO movie);
        ResponseDTO EditMovie(MovieDTO movie);
        ResponseDTO DeleteMovie(MovieDTO movie);
    }
}
