using MoneyShare.Application.Contracts.DTOs;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Users;

namespace MoneyShare.Application.Contracts.Interfaces;

public interface IUserService
{
    Task<List<UserDTO>> GetUsers();
    Task<UserDTO?> GetUserById(Guid id);
    decimal GetLoan(Guid id);
    IEnumerable<Bill> GetAllBillsByUser(Guid userId);
}
