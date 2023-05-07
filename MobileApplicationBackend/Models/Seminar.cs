using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileApplicationBackend.Models;

[Table("seminars")]
public class Seminar
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("date")]
    public DateTime Date { get; init; }

    [Column("name")]
    public string Name { get; init; }

    [Column("place")]
    public string Place { get; init; }

    [Column("description")]
    public string Description { get; init; }
}