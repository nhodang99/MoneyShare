using SharedKernel;

namespace MoneyShare.Domain.Groups;

public class Group : AuditEntity
{
    public required string Name { get; set; }
}
