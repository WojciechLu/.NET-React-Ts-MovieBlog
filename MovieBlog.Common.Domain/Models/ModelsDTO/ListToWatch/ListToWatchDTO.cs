namespace MovieBlog.Domain.Common.Models.ModelsDTO;

public class ListToWatchDTO
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public IList<MovieListDTO> MoviesList { get; set; }
}
