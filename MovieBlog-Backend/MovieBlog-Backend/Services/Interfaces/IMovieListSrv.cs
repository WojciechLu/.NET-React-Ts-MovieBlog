using MovieBlog_Backend.Models;
using MovieBlog_Backend.Models.ModelsDTO;

namespace MovieBlog_Backend.Services.Interfaces
{
    public interface IMovieListSrv
    {
        ResponseDTO AddMovieToList(AddMovieListDTO addMovieList);
        ResponseDTO RemoveMovieFromList(AddMovieListDTO addMovieList);
        MoviesDTO GetMoviesFromList(int listId);
        MovieLists GetMovieLists();
        MoviesDTO GetMoviesFromListByCategory(MovieListCategoryDTO movieCategory);
    }
}
