using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileApplicationBackend.Models;

[Table("trials")]
public class TrialForm
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
    
    [Column("email")]
    public string Email { get; set; }
    
    [Column("date")]
    public DateTime Date { get; set; }
    
    [Column("comment")]
    public string? Comment { get; set; }
}