using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyShare.API.Extensions;
using MoneyShare.API.Infrastructure;
using MoneyShare.Application.Bills;
using MoneyShare.Application.Bills.GetById;
using SharedKernel;

namespace MoneyShare.API.Controllers;

[ApiController]
[Route("/bills")]
public class BillController(IMediator mediator) : ControllerBase
{
    [Route("{billId}")]
    [HttpGet]
    public async Task<IResult> GetBillById(Guid billId)
    {
        var query = new GetBillByIdQuery(billId);
        Result<BillDTO> result = await mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);
    }
}
