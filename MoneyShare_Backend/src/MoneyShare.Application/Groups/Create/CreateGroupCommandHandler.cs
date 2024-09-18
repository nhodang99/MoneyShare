using AutoMapper;
using MoneyShare.Application.Contracts.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Groups;
using SharedKernel;

namespace MoneyShare.Application.Groups.Create;

internal class EditGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : ICommandHandler<CreateGroupCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateGroupCommand command, CancellationToken cancellationToken)
    {
        if (await unitOfWork.Groups.AnyAsync(g => g.Name == command.Name, cancellationToken))
        {
            return Result.Failure<Guid>(GroupErrors.Existed(command.Name));
        }

        Group group = mapper.Map<Group>(command);
        group.Id = Guid.NewGuid();
        unitOfWork.Groups.Add(group);

        await unitOfWork.CommitAsync(cancellationToken);

        return group.Id;
    }
}
