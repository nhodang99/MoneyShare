using Microsoft.AspNetCore.Mvc;
using MoneyShare.API.Services;
using MoneyShare.Domain.Users;

namespace MoneyShare.API.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _service;

        public UsersController(UsersService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _service.GetAll();
        }

        [Route("{id}")]
        [HttpGet]
        public User GetUserById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            if (user == null)
            {
                return BadRequest(user);
            }
            _service.Add(user);
            return Created();
        }

        [Route("edit/{id}")]
        [HttpPost]
        public IActionResult Edit(int id, User user)
        {
            if (user == null || id != user.Id)
            {
                return BadRequest(user);
            }
            _service.Update(id, user);
            return Ok(user);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var user = _service.GetById(id);
            if (user != null)
            {
                _service.DeleteById(id);
                return Ok(user);
            }
            return NotFound();
        }
    }
}
