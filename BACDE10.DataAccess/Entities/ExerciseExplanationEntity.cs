using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACDE10.DataAccess.Entities;

public class ExerciseExplanationEntity : AuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(TypeName = "varchar(500)")]
    public string Value { get; set; } = null!;

    public int? TypeId { get; set; }

    public int ExerciseId { get; set; }

    [ForeignKey(nameof(ExerciseId))]
    public ExerciseEntity Exercise { get; set; } = null!;
}
