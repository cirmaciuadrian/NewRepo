using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACDE10.DataAccess.Entities;

public class StudentEntity : AuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "varchar(50)")]
    public string Surname { get; set; } = null!;

    [Column(TypeName = "varchar(12)")]
    public string? PhoneNumber { get; set; }
}
