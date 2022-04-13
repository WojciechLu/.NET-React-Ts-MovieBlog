using Microsoft.AspNetCore.Mvc;
using MovieBlog.Domain.Common.Models.ModelsDTO;
using MovieBlog.Infrastructure.EntityFramework;

namespace MovieBlog_Backend.Controllers
{
    [Route("[controller]/[action]")]
    public class RegisterController: Controller
    {
        private readonly ReviewDbContext dbContext;

        public RegisterController(ReviewDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public ResponseDTO Register([FromBody]UserDTO newUser)
        {
            if(newUser != null)
            {
                var user = dbContext.Users.Where(u => u.Email == newUser.Email).FirstOrDefault();
                try
                {
                    var registeredUser = new User
                    {
                        Email = newUser.Email,
                        Id = newUser.Id,
                        Name = newUser.Name,
                        Password = newUser.Password,
                        IdListToWatch = newUser.Id,
                        Reviews = new List<Review>()
                    };
                    var newList = new ListToWatch() { Id = newUser.Id, Owner = registeredUser, OwnerId = registeredUser.Id, MoviesLists = new List<MovieList>() };
                    registeredUser.ToWatch = newList;
                    dbContext.Users.Add(registeredUser);
                    dbContext.ToWatch.Add(newList);
                    dbContext.SaveChanges();
                    return new ResponseDTO { Code = 200, Message = "Registered successfully", Status = "Success" };
                }
                catch(Exception ex)
                {
                    return new ResponseDTO { Code = 400, Message = ex.Message, Status = "Failed" };
                }
            }
            return new ResponseDTO { Code = 400, Message = "Error with register", Status = "Failed" };
        }

        [HttpPost]
        public ResponseDTO Login ([FromBody] UserDTO loginUser)
        {
            if(loginUser != null)
            {
                var user = dbContext.Users.Where(u => u.Email == loginUser.Email && u.Password == loginUser.Password).FirstOrDefault();
                if(user != null)
                {
                    return new ResponseDTO { Code = 200, Message = "Logged in successfully", Status = "Success" };
                }
            }
            return new ResponseDTO { Code = 400, Message = "Error with login", Status = "Failed" };
        }
    }
}
