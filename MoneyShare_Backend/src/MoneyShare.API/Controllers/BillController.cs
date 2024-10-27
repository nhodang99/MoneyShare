﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyShare.API.Extensions;
using MoneyShare.API.Infrastructure;
using MoneyShare.Application.Bills;
using MoneyShare.Application.Bills.Complete;
using MoneyShare.Application.Bills.Create;
using MoneyShare.Application.Bills.Delete;
using MoneyShare.Application.Bills.Edit;
using MoneyShare.Application.Bills.GetAll;
using MoneyShare.Application.Bills.GetById;
using SharedKernel;

namespace MoneyShare.API.Controllers;

[ApiController]
[Route("/bills")]
public class BillController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetAllBills()
    {
        var query = new GetAllBillsQuery();
        Result<IEnumerable<BillDto>> result = await mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Route("{billId}")]
    [HttpGet]
    public async Task<IResult> GetBillById(Guid billId)
    {
        var query = new GetBillByIdQuery(billId);
        Result<BillDto> result = await mediator.Send(query);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Route("delete/{billId}")]
    [HttpPost]
    public async Task<IResult> DeleteBillById(Guid billId)
    {
        var command = new DeleteBillCommand(billId);
        Result result = await mediator.Send(command);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }

    [Route("edit")]
    [HttpPost]
    public async Task<IResult> EditBillById([FromBody] EditBillCommand command)
    {
        Result result = await mediator.Send(command);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }

    [Route("create")]
    [HttpPost]
    public async Task<IResult> AddBill([FromBody] CreateBillCommand command)
    {
        var result = await mediator.Send(command);

        return result.Match(Results.Ok, CustomResults.Problem);
    }

    [Route("complete/{billId}")]
    [HttpPost]
    public async Task<IResult> CompleteBill(Guid billId)
    {
        var command = new CompleteBillCommand(billId);
        var result = await mediator.Send(command);

        return result.Match(Results.NoContent, CustomResults.Problem);
    }
}
