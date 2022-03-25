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

        public ResponseDTO AddMovieToList(int movieId, int listId)
        {
            var result = context.MoviesList.FirstOrDefault(ml => ml.ListId == listId || ml.MovieId == movieId);
            var listToCheck = context.ToWatch.FirstOrDefault(t => t.Id == listId);
            var movieToCheck = context.Movies.FirstOrDefault(m => m.Id == movieId);
            if(listToCheck != null && movieToCheck != null)
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
                catch(Exception ex)
                {
                    return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Failed" };
                }
            } 
            else return new ResponseDTO() { Code = 400, Message = "Not found movie or list with id", Status = "Failed" };
            

            /*if (list != null)
            {
                if (movieToAdd != null)
                {
                    try
                    {
                        if (list != null)
                        {
                            return new ResponseDTO() { Code = 400, Message = "Movie is already added to list", Status = "Failed" };
                        }
                        else
                        {
                            var newMovieList = new MovieList
                            {
                                List = listToAdd,
                                ListId = listToAdd.Id,
                                Movie = movieToAdd,
                                MovieId = movieToAdd.Id
                            };

                            if(listToAdd.MoviesLists == null)
                            {
                                listToAdd.MoviesLists = new List<MovieList>();
                            }
                            listToAdd.MoviesLists.Add(newMovieList);

                            if(movieToAdd.MovieLists == null)
                            {
                                movieToAdd.MovieLists = new List<MovieList>();
                            }
                            movieToAdd.MovieLists.Add(newMovieList);

                            context.MoviesList.Add(newMovieList);
                            context.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Failed" };
                    }
                    return new ResponseDTO { Code = 200, Message = "Successfully added movie to watch list", Status = "Success" };
                }
                else return new ResponseDTO { Code = 400, Message = "Movie with this id doesnt exist", Status = "Failed" };
            }
            else return new ResponseDTO { Code = 400, Message = "List with this owner id doesn't exist", Status = "Failed" };*/
        }

        public MoviesDTO GetMoviesFromList(int listId)
        {
            var result = context.MoviesList.FirstOrDefault(ml => ml.ListId == listId);
            var operatingList = context.ToWatch.FirstOrDefault(t => t.Id == result.ListId);
            if (operatingList != null)
            {
                try
                {
                    MoviesDTO movies = new MoviesDTO();
                    movies.moviesList = new List<MovieDTO>();

                    var movieList = operatingList.MoviesLists.ToList();
                    foreach (MovieList movie in movieList)
                    {
                        var movieToRead = context.Movies.FirstOrDefault(m => m.Id == movie.MovieId);
                        movies.moviesList.Add(new MovieDTO { Id = movieToRead.Id, Category = movieToRead.Category, Title = movieToRead.Title, Image = movieToRead.Image });
                    }
                    return movies;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
            else return null;
        }

        public ResponseDTO RemoveMovieFromList(int movieId, int listId)
        {
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

        public MovieLists GetMovieLists()
        {
            var resutl = context.MoviesList.ToList();

            MovieLists list = new MovieLists();
            list.movieLists = new List<MovieList>();

            foreach(var item in resutl)
            {
                var listToWatch = context.ToWatch.FirstOrDefault(t => t.Id == item.ListId);

                var movie = context.Movies.FirstOrDefault(m => m.Id == item.MovieId);

                list.movieLists.Add(new MovieList() { ListId = item.ListId, MovieId = item.MovieId});
            }
            return list;
        }
    }
}
