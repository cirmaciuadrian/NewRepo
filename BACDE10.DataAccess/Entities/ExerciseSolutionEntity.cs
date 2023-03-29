using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACDE10.DataAccess.Entities;

public class ExerciseSolutionEntity : AuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? SolutionValue { get; set; }

    public int ExerciseId { get; set; }

    public int? ExerciseCaseId { get; set; }

    [ForeignKey(nameof(ExerciseId))]
    public ExerciseEntity Exercise { get; set; } = null!;
}
