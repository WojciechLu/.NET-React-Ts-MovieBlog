using MovieBlog.Domain.Common.Models.ModelsDTO;

namespace MovieBlog.Domain.Interfaces.Infrastructure;

public interface IMovieListSrv
{
    ResponseDTO AddMovieToList(AddMovieListDTO addMovieList);
    ResponseDTO RemoveMovieFromList(AddMovieListDTO addMovieList);
    MoviesDTO GetMoviesFromList(int listId);
    MovieListsDTO GetMovieLists();
    MoviesDTO GetMoviesFromListByCategory(MovieListCategoryDTO movieCategory);
}
