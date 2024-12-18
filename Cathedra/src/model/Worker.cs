using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cathedra.model;

[Table("worker")]
public class Worker
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("worker_id")]
    public long id { get; set; }
    
    [Column("name")]
    public string name { get; set; }
    
    [Column("last_name")]
    public string lastName { get; set; }
    
    [Column("type")]
    public string type { get; set; }

    public Worker(string name, string lastName, string type)
    {
        this.name = name;
        this.lastName = lastName;
        this.type = type;
    }
}