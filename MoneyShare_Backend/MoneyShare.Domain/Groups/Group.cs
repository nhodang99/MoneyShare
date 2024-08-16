using MoneyShare.Domain.Base;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Groups_Users;
using MoneyShare.Domain.Users;
using System.ComponentModel.DataAnnotations;

namespace MoneyShare.Domain.Groups
{
    public partial class Group : AuditEntity<int>
    {
        public required string Name { get; set; }

        public virtual ICollection<Group_User>? Groups_Users { get; set; }
        public virtual ICollection<Bill>? Bills { get; set; }

        public Group()
        {
            Groups_Users = new HashSet<Group_User>();
            Bills = new HashSet<Bill>();
        }
    }
}
