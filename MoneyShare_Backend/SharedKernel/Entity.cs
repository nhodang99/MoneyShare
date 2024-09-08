using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SharedKernel;

public interface IBaseEntity
{
    Guid Id { get; set; }
}

public interface IDeleteEntity
{
    bool IsDeleted { get; set; }
}

public interface IAuditEntity
{
    DateTime CreatedDate { get; set; }
    Guid CreatedBy { get; set; }
    DateTime? UpdatedDate { get; set; }
    Guid UpdatedBy { get; set; }
}

public abstract class DeleteEntity : IBaseEntity, IDeleteEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
}

public abstract class AuditEntity : DeleteEntity, IAuditEntity
{
    public DateTime CreatedDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Guid UpdatedBy { get; set; }
}
