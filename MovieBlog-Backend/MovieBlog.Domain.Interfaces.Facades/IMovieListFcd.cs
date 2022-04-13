using MovieBlog.Domain.Common.Models.ModelsDTO;

namespace MovieBlog.Domain.Interfaces.Facades;

public interface IMovieListFcd
{
    ResponseDTO AddMovieToList(AddMovieListDTO addMovieList);
    ResponseDTO RemoveMovieFromList(AddMovieListDTO addMovieList);
    MoviesDTO GetMoviesFromList(int listId);
    MovieListsDTO GetMovieLists();
    MoviesDTO GetMoviesFromListByCategory(MovieListCategoryDTO movieCategory);
}
