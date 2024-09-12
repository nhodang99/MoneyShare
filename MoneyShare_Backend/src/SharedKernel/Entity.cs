using System.ComponentModel.DataAnnotations;

namespace SharedKernel;

public abstract class EntityBase : HasDomainEventsBase
{
    [Key]
    public Guid Id { get; set; }
}

public abstract class DeleteEntity : EntityBase
{
    public bool IsDeleted { get; set; }
}

public abstract class AuditEntity : DeleteEntity
{
    public DateTime CreatedDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Guid? UpdatedBy { get; set; }
}
