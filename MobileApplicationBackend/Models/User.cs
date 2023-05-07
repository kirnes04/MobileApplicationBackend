using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MobileApplicationBackend.Models;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("email")]
    public string Email { get; init; }
    
    [Column("password")]
    public string Password { get; init; }
    
    [Column("role")]
    public string Role { get; init; }
    
    [Column("description")]
    public string? Description { get; init; }

    [Column("name")]
    public string FullName { get; init; }
    
    [Column("dan")]
    public string? Dan { get; set; }

    [Column("category")]
    public string? Category { get; set; }

    [Column("direction")]
    public string? Direction { get; set; }

    [Column("participation")]
    public bool? Participation { get; set; }
    
    [Column("medals")]
    public string? Medals { get; set; }
    
    [Column("picture")]
    public string? Picture { get; set; }
}