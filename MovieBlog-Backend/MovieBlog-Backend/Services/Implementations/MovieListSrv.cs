using MovieBlog_Backend.Data;
using MovieBlog_Backend.Models;
using MovieBlog_Backend.Models.ModelsDTO;
using MovieBlog_Backend.Services.Interfaces;

namespace MovieBlog_Backend.Services.Implementations
{
    public class MovieListSrv : IMovieListSrv
    {
        private readonly ReviewDbContext context;
        public MovieListSrv(ReviewDbContext context)
        {
            this.context = context;
        }

        public ResponseDTO AddMovieToList(AddMovieListDTO addMovieList)
        {
            if (addMovieList != null)
            {
                var listId = addMovieList.listId;
                var movieId = addMovieList.movieId;

                var result = context.MoviesList.FirstOrDefault(ml => ml.ListId == listId || ml.MovieId == movieId);
                var listToCheck = context.ToWatch.FirstOrDefault(t => t.Id == listId);
                var movieToCheck = context.Movies.FirstOrDefault(m => m.Id == movieId);
                if (listToCheck != null && movieToCheck != null)
                {
                    try
                    {
                        var list = context.MoviesList.FirstOrDefault(ml => ml.ListId == listId && ml.MovieId == movieId);
                        if (list == null)
                        {
                            var newMovieList = new MovieList
                            {
                                List = listToCheck,
                                ListId = listToCheck.Id,
                                Movie = movieToCheck,
                                MovieId = movieToCheck.Id
                            };
                            var listToUpdate = context.ToWatch.FirstOrDefault(l => l.Id == listId);
                            if (listToUpdate.MoviesLists == null)
                            {
                                listToUpdate.MoviesLists = new List<MovieList>();
                            }
                            listToUpdate.MoviesLists.Add(newMovieList);

                            var movieToUpdate = context.Movies.FirstOrDefault(m => m.Id == movieId);
                            if (movieToUpdate.MovieLists == null)
                            {
                                movieToUpdate.MovieLists = new List<MovieList>();
                            }
                            movieToUpdate.MovieLists.Add(newMovieList);

                            context.SaveChanges();
                            return new ResponseDTO() { Code = 200, Message = "Added", Status = "Success" };
                        }
                        else return new ResponseDTO() { Code = 400, Message = "Movie is already added to list", Status = "Failed" };
                    }
                    catch (Exception ex)
                    {
                        return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Failed" };
                    }
                }
                else return new ResponseDTO() { Code = 400, Message = "Not found movie or list with id", Status = "Failed" };
            }
            else return new ResponseDTO() { Code = 400, Message = "Add movie to list is null", Status = "Failed" };
        }

        public MoviesDTO GetMoviesFromList(int listId)
        {
            var list = context.ToWatch.FirstOrDefault(t => t.Id == listId);
            var result = context.MoviesList.Where(ml => ml.ListId == listId).ToList();

            if (list != null)
            {
                try
                {
                    MoviesDTO movies = new MoviesDTO();
                    movies.moviesList = new List<MovieDTO>();

                    foreach (MovieList item in list.MoviesLists)
                    {
                        var movieToRead = context.Movies.FirstOrDefault(m => m.Id == item.MovieId);
                        movies.moviesList.Add(new MovieDTO { Id = movieToRead.Id, Category = movieToRead.Category, Title = movieToRead.Title, Image = movieToRead.Image });
                    }
                    return movies;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else return null;
        }

        public ResponseDTO RemoveMovieFromList(AddMovieListDTO addMovieList)
        {
            if(addMovieList != null)
            {
                var listId = addMovieList.listId;
                var movieId = addMovieList.movieId;

                var movieList = context.MoviesList.FirstOrDefault(ml => ml.MovieId == movieId && ml.ListId == listId);
                var movieToRemove = context.Movies.FirstOrDefault(m => m.Id == movieId);
                var listToWatch = context.ToWatch.FirstOrDefault(l => l.Id == listId);
                if ((movieList != null) && (movieToRemove != null) && (listToWatch != null))
                {
                    try
                    {
                        movieToRemove.MovieLists.Remove(movieList);
                        listToWatch.MoviesLists.Remove(movieList);
                        context.MoviesList.Remove(movieList);
                        context.SaveChanges();
                        return new ResponseDTO() { Code = 200, Message = "Removed movie from list", Status = "Success" };
                    }
                    catch (Exception ex)
                    {
                        return new ResponseDTO() { Code = 400, Message = ex.Message, Status = "Failed" };
                    }
                }
                else return new ResponseDTO() { Code = 400, Message = "Not found movielist or movie or list to watch", Status = "Failed" };
            }
            else return new ResponseDTO() { Code = 400, Message = "Add movie to list is null", Status = "Failed" };
        }

        public MovieLists GetMovieLists()
        {
            var resutl = context.MoviesList.ToList();

            MovieLists list = new MovieLists();
            list.movieLists = new List<MovieList>();

            foreach (var item in resutl)
            {
                var listToWatch = context.ToWatch.FirstOrDefault(t => t.Id == item.ListId);

                var movie = context.Movies.FirstOrDefault(m => m.Id == item.MovieId);

                list.movieLists.Add(new MovieList() { ListId = item.ListId, MovieId = item.MovieId });
            }
            return list;
        }
        public MoviesDTO GetMoviesFromListByCategory(MovieListCategoryDTO movieCategory)
        {
            if (movieCategory != null)
            {
                var listId = movieCategory.listId;
                var list = context.ToWatch.FirstOrDefault(t => t.Id == listId);
                var result = context.MoviesList.Where(ml => ml.ListId == listId).ToList();

                if (list != null)
                {
                    try
                    {
                        var category = movieCategory.category;

                        MoviesDTO movies = new MoviesDTO();
                        movies.moviesList = new List<MovieDTO>();

                        foreach (MovieList item in list.MoviesLists)
                        {
                            var movieToRead = context.Movies.FirstOrDefault(m => m.Id == item.MovieId);
                            if (movieToRead.Category == category)
                            {
                                movies.moviesList.Add(new MovieDTO { Id = movieToRead.Id, Category = movieToRead.Category, Title = movieToRead.Title, Image = movieToRead.Image });
                            }
                        }
                        return movies;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
            return null;
        }
    }
}
