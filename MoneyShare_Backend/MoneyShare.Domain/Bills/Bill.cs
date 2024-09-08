using SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace MoneyShare.Domain.Bills;

public class Bill : AuditEntity
{
    [Required(ErrorMessage = "Bill title is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; }
    public BillStatus Status { get; set; }
    public Guid GroupId { get; set; }

    public Guid PayerId { get; set; }
}
