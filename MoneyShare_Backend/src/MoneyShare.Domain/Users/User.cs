#region

using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Groups;
using SharedKernel;

#endregion

namespace MoneyShare.Domain.Users;

public class User : DeleteEntity
{
    public required string UserName { get; set; }

    public required string Email { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new HashSet<Group>();
    public virtual ICollection<Bill> Bills { get; set; } = new HashSet<Bill>();
}