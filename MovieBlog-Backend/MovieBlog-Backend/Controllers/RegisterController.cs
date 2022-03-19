﻿using Microsoft.AspNetCore.Mvc;
using MovieBlog_Backend.Data;
using MovieBlog_Backend.Models;
using MovieBlog_Backend.Models.ModelsDTO;

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
                if (user == null)
                {
                    var registeredUser = new User
                    {
                        Email = newUser.Email,
                        Id = newUser.Id,
                        Name = newUser.Name,
                        Password = newUser.Password,
                        ToWatch = new ListToWatch { Id = newUser.Id }
                    };
                    dbContext.Users.Add(registeredUser);
                    dbContext.SaveChanges();
                    return new ResponseDTO { Code = 200, Message = "Registered successfully", Status = "Success" };
                }
            }
            return new ResponseDTO { Code = 400, Message = "Error with register", Status = "Failed" };
        }

        [HttpPost]
        public ResponseDTO Login ([FromBody] UserDTO loginUser)
        {
            if(loginUser != null)
            {
                var user = dbContext.Users.Where(u => u.Id == loginUser.Id).FirstOrDefault();
                if(user != null)
                {
                    return new ResponseDTO { Code = 200, Message = "Logged in successfully", Status = "Success" };
                }
            }
            return new ResponseDTO { Code = 400, Message = "Error with login", Status = "Failed" };
        }
    }
}
