using MoneyShare.Domain.Base;
using MoneyShare.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

using Group = MoneyShare.Domain.Groups.Group;

namespace MoneyShare.Domain.Bills
{
    [Table("Bills")]
    public partial class Bill : AuditEntity<int>
    {
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public BillStatus Status {  get; set; }
        public int GroupId { get; set; }

        [ForeignKey("Users")]
        public int PayerId { get; set; }


        [ForeignKey(nameof(GroupId))]
        public virtual Group Group { get; set; }

        public virtual User Payer { get; set; }
    }

    public enum BillStatus
    {
        Pending,
        Completed
    }

}
