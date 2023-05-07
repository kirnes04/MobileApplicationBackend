using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileApplicationBackend.Models;

[Table("feedback")]
public class Feedback
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string FullName { get; set; }
    
    [Column("number")]
    public string PhoneNumber { get; set; }
    
    [Column("email")]
    public string Email { get; set; }
    
    [Column("content")]
    public string Content { get; set; }
}