using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileApplicationBackend.Models;

[Table("tournament_participants")]
public class TournamentForm
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string FullName { get; set; }
    
    [Column("birthday")]
    public DateTime Birthday { get; set; }
    
    [Column("number")]
    public string PhoneNumber { get; set; }
    
    [Column("category")]
    public string Category { get; set; }
}