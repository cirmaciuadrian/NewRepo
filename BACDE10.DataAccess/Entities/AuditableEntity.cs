namespace BACDE10.DataAccess.Entities;

public abstract class AuditableEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Guid CreatedBy { get; set; } = Guid.Empty;
    public Guid? UpdatedBy { get; set; }
}
