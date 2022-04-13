using MovieBlog.Domain.Common.Models.ModelsDTO;
using MovieBlog.Domain.Interfaces.Facades;
using MovieBlog.Domain.Interfaces.Infrastructure;

namespace MovieBlog.Domain.Facades;

public class UserFcd : IUserFcd
{
    private readonly IUserSrv userSrv;
    public UserFcd(IUserSrv userSrv)
    {
        this.userSrv = userSrv;
    }

    public ResponseDTO DeleteUser(UserDTO user)
    {
        return userSrv.DeleteUser(user);
    }

    public ResponseDTO EditUser(UserDTO user)
    {
        return userSrv.EditUser(user);
    }

    public UsersDTO GetAllUsers()
    {
        return userSrv.GetAllUsers();
    }
}
