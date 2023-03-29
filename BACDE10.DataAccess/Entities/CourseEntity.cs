using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACDE10.DataAccess.Entities;

public class CourseEntity : AuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; } = null!;

    public int? CategoryId { get; set; }

    public List<CourseDetailsEntity> CourseDetails { get; set; } = new List<CourseDetailsEntity>();
    public List<ExerciseEntity> Exercises { get; set; } = new List<ExerciseEntity>();
}
