namespace MoneyShare.Application.Contracts.Requests;

public sealed record LoginReq(string Email, string Password);

public sealed record RegisterReq(string UserName, string Email, string Password);
