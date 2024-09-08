using MoneyShare.Application.Contracts.Interfaces;
using MoneyShare.Domain.Users;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Repositories;
using MoneyShare.Application.Contracts.DTOs;

namespace MoneyShare.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<User> _userRepository;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _userRepository = _unitOfWork.Repository<User>();
    }

    public async Task<List<UserDTO>> GetUsers()
    {
        var users = await _userRepository.GetAllAsync();
        List<UserDTO> userDTOs = [];
        foreach (var user in users)
        {
            userDTOs.Add(new UserDTO(user.Id, user.UserName, user.Email));
        }
        return userDTOs;
    }

    public async Task<UserDTO?> GetUserById(Guid id)
    {
        var user = await _userRepository.GetAsync(id);
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
