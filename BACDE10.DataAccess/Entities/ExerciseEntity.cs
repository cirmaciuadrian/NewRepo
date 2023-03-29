using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACDE10.DataAccess.Entities;

public class ExerciseEntity : AuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(TypeName = "varchar(500)")]
    public string Requirement { get; set; } = null!;

    public int? TypeId { get; set; } 

    public int CourseId { get; set; }

    [ForeignKey(nameof(CourseId))]
    public CourseEntity Course { get; set; } = null!;
    public List<ExerciseCaseEntity> ExerciseCases { get; set; } = new List<ExerciseCaseEntity>();
    public List<ExerciseSolutionEntity> Solutions { get; set; } = new List<ExerciseSolutionEntity>();
    public List<ExerciseExplanationEntity> Explanations { get; set; } = new List<ExerciseExplanationEntity>();
}
