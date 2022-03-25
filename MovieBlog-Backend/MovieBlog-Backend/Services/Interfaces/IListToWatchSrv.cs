using MovieBlog_Backend.Models.ModelsDTO;

namespace MovieBlog_Backend.Services.Interfaces
{
    public interface IListToWatchSrv
    {
        ResponseDTO RemoveMovie(int userId, string title);
        MoviesDTO GetMovies(int userId);
        MoviesDTO GetMoviesByCategory(int userId, string category);
        ListsToWatchDTO GetAllLists();
    }
}
