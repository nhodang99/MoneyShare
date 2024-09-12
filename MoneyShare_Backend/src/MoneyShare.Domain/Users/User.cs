using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Groups;
using SharedKernel;

namespace MoneyShare.Domain.Users;

public class User : DeleteEntity
{
    public required string UserName { get; set; }

    public required string Email { get; set; }

    public required string PasswordHash { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = null!;
    public virtual ICollection<Bill> Bills { get; set; } = null!;

    public User()
    {
        Groups = new HashSet<Group>();
        Bills = new HashSet<Bill>();
    }
}
