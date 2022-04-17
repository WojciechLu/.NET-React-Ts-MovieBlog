using MovieBlog.Domain.Common.Models.ModelsDTO;
using MovieBlog.Domain.Interfaces.Infrastructure;
using MovieBlog.Infrastructure.EntityFramework.Entities;

namespace MovieBlog.Infrastructure.EntityFramework;

public class UserSrv : IUserSrv
{
    private readonly ReviewDbContext context;
    public UserSrv(ReviewDbContext context)
    {
        this.context = context;
    }

    public ResponseDTO DeleteUser(UserDTO user)
    {
        if (user != null)
        {
            try
            {
                var deleteUser = context.Users.FirstOrDefault(u => u.Id == user.Id);
                if(deleteUser == null) return new ResponseDTO { Code = 200, Message = "Not found user", Status = "Failed" };

                context.Users.Remove(deleteUser);
                context.SaveChanges();

                return new ResponseDTO { Code = 200, Message = "User deleted", Status = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Failed" };
            }
        }
        return new ResponseDTO { Code = 400, Message = "Passed empty user", Status = "Failed" };
    }

    public ResponseDTO EditUser(UserDTO user)
    {
        if (user != null)
        {
            try
            {
                var editUser = context.Users.FirstOrDefault(u => u.Id == user.Id);
                if(editUser == null) return new ResponseDTO { Code = 200, Message = "Not found user", Status = "Failed" };
                
                editUser.Email = user.Email;
                editUser.Name = user.Name;
                editUser.Password = user.Password;

                context.Update(editUser);
                context.SaveChanges();

                return new ResponseDTO { Code = 200, Message = "User edited", Status = "Success" };
            }
            catch (Exception ex)
            {
                return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Failed" };
            }
        }
        return new ResponseDTO { Code = 400, Message = "Passed empty user", Status = "Failed" };
    }

    public UsersDTO GetAllUsers()
    {
        var result = context.Users.ToList();
        UsersDTO users = new UsersDTO();
        users.usersList = new List<UserDTO>();

        foreach(User user in result)
        {
            var userDTO = new UserDTO { Email = user.Email, Id = user.Id, Name = user.Name, Password = user.Password };
            users.usersList.Add(userDTO);
        }
        return users;
    }
}
