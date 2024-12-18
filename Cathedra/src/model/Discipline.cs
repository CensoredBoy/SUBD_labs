using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cathedra.model;

[Table("discipline")]
public class Discipline
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("discipline_id")]
    public long id { get; set; }
    
    [Column("name")]
    public string name { get; set; }

    [Column("professor_id")]
    public long professorId { get; set; }

    [Column("helper_id")]
    public long helperId { get; set; }
    
}