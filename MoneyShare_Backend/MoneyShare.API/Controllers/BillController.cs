using Microsoft.AspNetCore.Mvc;
using MoneyShare.Application.Contracts.DTOs;
using MoneyShare.Application.Contracts.Interfaces;

namespace MoneyShare.API.Controllers;

[ApiController]
[Route("/bills")]
public class BillController : ControllerBase
{
    private readonly IBillService _service;

    public BillController(IBillService service)
    {
        _service = service;
    }

    [Route("{id}")]
    [HttpGet]
    public BillDTO GetBillById(Guid id)
    {
        return _service.GetBillById(id);
    }
}
