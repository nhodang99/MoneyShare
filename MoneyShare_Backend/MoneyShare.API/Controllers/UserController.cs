using Microsoft.AspNetCore.Mvc;
using MoneyShare.Application.Contracts.DTOs;
using MoneyShare.Application.Contracts.Interfaces;

namespace MoneyShare.API.Controllers;

[ApiController]
[Route("/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<List<UserDTO>> GetUsers()
    {
        var users = _service.GetUsers();
        return users;
    }

    [Route("user/{userId}")]
    [HttpGet]
    public async Task<ActionResult<UserDTO>> GetUserById(Guid id)
    {
        var user = await _service.GetUserById(id);
        return user is null ? NotFound() : user;
    }

    [Route("bills")]
    [HttpGet]
    public IEnumerable<BillDTO> GetBillsByUser(Guid userId)
    {
        return [];
    }
}
