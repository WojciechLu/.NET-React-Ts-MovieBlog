using MovieBlog_Backend.Models;
using MovieBlog_Backend.Models.ModelsDTO;

namespace MovieBlog_Backend.Services.Interfaces
{
    public interface IUserSrv
    {
        User GetAllUsers();
        ResponseDTO EditUser(User user);
        ResponseDTO DeleteUser(User user);
    }
}
