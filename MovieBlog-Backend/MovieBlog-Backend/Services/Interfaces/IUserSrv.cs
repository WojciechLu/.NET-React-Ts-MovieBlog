using MovieBlog_Backend.Models;
using MovieBlog_Backend.Models.ModelsDTO;

namespace MovieBlog_Backend.Services.Interfaces
{
    public interface IUserSrv
    {
        UsersDTO GetAllUsers();
        ResponseDTO EditUser(UserDTO user);
        ResponseDTO DeleteUser(UserDTO user);
    }
}
