#region

using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Users;
using SharedKernel;

#endregion

namespace MoneyShare.Domain.Groups;

public class Group : AuditEntity, IAggregateRoot
{
    public required string Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
    public virtual ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();
}