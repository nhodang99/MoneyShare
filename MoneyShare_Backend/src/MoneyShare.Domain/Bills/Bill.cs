using MoneyShare.Domain.Groups;
using MoneyShare.Domain.Users;
using SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyShare.Domain.Bills;

public class Bill : AuditEntity
{
    public required string Title { get; set; }
    public required decimal Price { get; set; }
    public BillStatus Status { get; set; }

    public Guid GroupId { get; set; }

    [ForeignKey("Users")]
    public Guid PayerId { get; set; }

    public virtual User Payer { get; set; } = null!;
    public virtual Group Group { get; set; } = null!;
}
