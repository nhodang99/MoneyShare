using AutoMapper;
using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain;
using SharedKernel;

namespace MoneyShare.Application.Users.GetAll;

internal sealed class GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetAllUsersQuery, List<UserDTO>>
{
    public async Task<Result<List<UserDTO>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        var users = await unitOfWork.Users.GetAllAsync(cancellationToken);

        List<UserDTO> userDtos = [];

        foreach (var user in users)
        {
            userDtos.Add(mapper.Map<UserDTO>(user));
        }
        return userDtos;
    }
}
