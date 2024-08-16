using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoneyShare.API.Base;
using MoneyShare.API.Services;
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
            return Created();
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

        [Route("add_users")]
        [HttpPost]
        public IActionResult AddUsers([FromBody] GroupUserRequestBody reqBody)
        {
            if (reqBody.groupId == 0 || reqBody.UserIds.IsNullOrEmpty())
            {
                return UnprocessableEntity(reqBody);
            }
            if (!_service.AddUsers(reqBody))
            {
                return ValidationProblem(); // @TODO: Other status code more meaningful?
            }
            return NoContent();
        }

        [Route("remove_users")]
        [HttpPost]
        public IActionResult RemoveUsers([FromBody] GroupUserRequestBody reqBody)
        {
            if (reqBody.groupId == 0 || reqBody.UserIds.IsNullOrEmpty())
            {
                return UnprocessableEntity(reqBody);
            }
            if (!_service.RemoveUsers(reqBody))
            {
                return ValidationProblem(); // @TODO: Other status code more meaningful?
            }
            return NoContent();
        }
    }
}
