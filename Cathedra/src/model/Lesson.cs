using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cathedra.model;

[Table("lesson")]
public class Lesson
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("lesson_id")]
    public long id { get; set; }

    [Column("discipline_id")]
    public long disciplineId { get; set; }
    
    [Column("start_time")]
    public DateTime startTime { get; set; }

    public Lesson(long disciplineId, DateTime startTime)
    {
        this.disciplineId = disciplineId;
        this.startTime = startTime;
    }

    public Lesson(long id, long disciplineId, DateTime startTime)
    {
        this.id = id;
        this.disciplineId = disciplineId;
        this.startTime = startTime;
    }
}