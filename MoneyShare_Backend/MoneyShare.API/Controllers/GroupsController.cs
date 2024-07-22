using Microsoft.AspNetCore.Mvc;
using MoneyShare.API.Services;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Groups;

namespace MoneyShare.API.Controllers
{
    [ApiController]
    [Route("/groups")]
    public class GroupsController : ControllerBase
    {
        private readonly GroupsService _service;

        public GroupsController(GroupsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Group> GetGroups()
        {
            return _service.GetAll();
        }

        [Route("{id}")]
        [HttpGet]
        public Group GetGroupById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public IActionResult Add(Group group)
        {
            if (group == null)
            {
                return BadRequest(group);
            }
            _service.Add(group);
            return Ok(group);
        }

        [Route("edit/{id}")]
        [HttpPost]
        public IActionResult Edit(int id, Group group)
        {
            if (group == null || id != group.Id)
            {
                return BadRequest(group);
            }
            _service.Update(id, group);
            return Ok(group);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var group = _service.GetById(id);
            if (group != null)
            {
                _service.DeleteById(id);
                return Ok(group);
            }
            return NotFound();
        }

        // [Route("add/user/{id}")]
        // [HttpPatch]
        // public IActionResult AddUser(int id)
        // {
            // if (_)
        // }
    }
}
