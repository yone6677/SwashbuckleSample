using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwashbuckleSample.Model;

namespace SwashbuckleSample.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private List<User> _users;
        public UsersController(List<User> users)
        {
            _users = users;
        }
        // GET api/values
        [HttpGet]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        public IActionResult Get()
        {
            return Ok(_users);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        public IActionResult Get(int id)
        {
            var user = _users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult Post(User user)
        {
            user.UserId = _users.Count + 1;
            _users.Add(user);
            return Created($"api/users/{user.UserId}", user);
        }

        [HttpPut]
        public IActionResult Put([FromBody]User user)
        {
            var us = _users.FirstOrDefault(u => u.UserId == user.UserId);
            if (us == null)
            {
                return NotFound();
            }
            us.UserName = user.UserName;
            us.Phone = user.Phone;

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.UserId == id);
            _users.Remove(user);
            return NoContent();
        }
    }
}
