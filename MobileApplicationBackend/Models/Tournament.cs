using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileApplicationBackend.Models;

[Table("tournaments")]
public class Tournament
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("description")]
    public string Description { get; init; }

    [Column("place")]
    public string Place { get; init; }

    [Column("name")]
    public string Name { get; init; }

    [Column("date")]
    public DateTime Date { get; init; }
    
    [Column("picture")]
    public string Picture { get; set; }
}