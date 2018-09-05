                                                                                       using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stormbreaker.api.Models.DTO;
using stormbreaker.api.Repositories;
using stormbreaker.api.Repositories.UserRepository;

namespace stormbreaker.api.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepo.GetAllUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRepo.GetUser(id);

            return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] UserDTO user)
        {
            _userRepo.AddUser(user);

            return Ok(user);
        }

        // POST api/values
        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromBody] UserDTO user)
        {
            _userRepo.UpdateUser(id, user);

            return Ok(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userRepo.DeleteUser(id);

            return Ok();
        }
    }
}