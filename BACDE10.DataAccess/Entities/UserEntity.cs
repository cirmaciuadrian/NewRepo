using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACDE10.DataAccess.Entities;

public class UserEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Email { get; set; } = null!;

    [MaxLength(255)]
    public string Password { get; set; } = null!;

    [Column(TypeName = "varchar(50)")]
    public string Username { get; set; } = null!;

    public Guid StudentId { get; set; }

    [ForeignKey(nameof(StudentId))]
    public StudentEntity Student { get; set; } = null!;
}
