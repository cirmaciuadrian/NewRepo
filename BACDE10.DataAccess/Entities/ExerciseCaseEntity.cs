using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACDE10.DataAccess.Entities;

public class ExerciseCaseEntity : AuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string Name { get; set; } = null!;

    public int? TypeId { get; set; }

    public int ExerciseId { get; set; }

    [ForeignKey(nameof(ExerciseId))]
    public ExerciseEntity Exercise { get; set; } = null!;
}