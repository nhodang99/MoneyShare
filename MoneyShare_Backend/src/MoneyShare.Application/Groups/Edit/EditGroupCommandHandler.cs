#region

using AutoMapper;
using MoneyShare.Application.Interfaces.Messaging;
using MoneyShare.Domain;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Interfaces;
using SharedKernel;

#endregion

namespace MoneyShare.Application.Groups.Edit;

internal class EditGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IGroupDomainService groupService)
    : ICommandHandler<EditGroupCommand>
{
    public async Task<Result> Handle(EditGroupCommand command, CancellationToken cancellationToken)
    {
        if (!await unitOfWork.Groups.AnyAsync(g => g.Id == command.Id, cancellationToken))
        {
            return Result.Failure<Guid>(GroupErrors.NotFound(command.Id));
        }

        Group group = mapper.Map<Group>(command);

        return await groupService.EditGroupAsync(group, cancellationToken);
    }
}