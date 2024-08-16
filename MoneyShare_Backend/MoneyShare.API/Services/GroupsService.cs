using MoneyShare.API.Base;
using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Groups_Users;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Domain.Users;
using MoneyShare.Infrastructure.Repositories;

namespace MoneyShare.API.Services
{
    public class GroupsService : BaseService<Group>
    {
        private readonly IGroupRepository Groups;

        public GroupsService(IUnitOfWork unitOfWork, IGroupRepository groupRepository) : base(unitOfWork)
        {
            Groups = groupRepository;
        }

        public bool AddUsers(GroupUserRequestBody reqBody)
        {
            var group = Groups.Get(reqBody.groupId);
            if (group == null)
            {
                return false;
            }

            foreach (var userId in reqBody.UserIds)
            {
                if (_unitOfWork.Repository<User>().Get(userId) == null)
                {
                    return false;
                }

                group.Groups_Users.Add(new Group_User
                {
                    GroupId = group.Id,
                    UserId = userId,
                });
            }
            _unitOfWork.Commit();
            return true;
        }

        public bool RemoveUsers(GroupUserRequestBody reqBody)
        {
            var group = Groups.Get(reqBody.groupId);
            if (group == null)
            {
                return false;
            }

            foreach (var userId in reqBody.UserIds)
            {
                var item = group.Groups_Users.FirstOrDefault(x => x.GroupId == userId);
                if (item == null)
                {
                    return false;
                }
                group.Groups_Users.Remove(item);
            }
            _unitOfWork.Commit();
            return true;
        }
    }
}
