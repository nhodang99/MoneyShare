using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Users;
using SharedKernel;

namespace MoneyShare.Domain.Groups;

public class Group : AuditEntity, IAggregateRoot
{
    public required string Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = null!;
    public virtual ICollection<Bill> Bills { get; set; } = null!;

    public Group()
    {
        Users = new HashSet<User>();
        Bills = new HashSet<Bill>();
    }
}
