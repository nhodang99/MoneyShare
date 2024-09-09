using MoneyShare.Application.Contracts.Interfaces;
using MoneyShare.Domain.Bills;
using MoneyShare.Application.Contracts.DTOs;
using MoneyShare.Domain;

namespace MoneyShare.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // Todo: remove this method
    public async Task<List<UserDTO>> GetUsers()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        List<UserDTO> userDTOs = [];
        foreach (var user in users)
        {
            userDTOs.Add(new UserDTO(user.Id, user.UserName, user.Email));
        }
        return userDTOs;
    }

    public async Task<UserDTO?> GetUserById(Guid id)
    {
        var user = await _unitOfWork.Users.GetAsync(id);
        if (user == null)
        {
            return default;
        }
        return new UserDTO(user.Id, user.UserName, user.Email);
    }

    public IEnumerable<Bill> GetAllBillsByUser(Guid userId)
    {
        return [];
    }

    public decimal GetLoan(Guid id)
    {
        return 0;
    }
}
