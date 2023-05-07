using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileApplicationBackend.Models;

[Table("events")]
public class Event
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("header")]
    public string Header { get; init; }

    [Column("date")]
    public DateTime Date { get; init; }

    [Column("place")]
    public string Place { get; init; }
    
    [Column("picture")]
    public string Picture { get; set; }
}