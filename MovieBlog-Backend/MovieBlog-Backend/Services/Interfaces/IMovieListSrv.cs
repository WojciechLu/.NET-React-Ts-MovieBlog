using MovieBlog_Backend.Models.ModelsDTO;

namespace MovieBlog_Backend.Services.Interfaces
{
    public interface IMovieListSrv
    {
        ResponseDTO AddMovieToList(int movieId, int listId);
        ResponseDTO RemoveMovieFromList(int movieId, int listId);
        MoviesDTO GetMoviesFromList(int listId);
    }
}
