using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileApplicationBackend.Models;
[Table("news")]
public class News
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("date")]
    public DateTime Date { get; init; }
    
    [Column("header")]
    public string Header { get; init; }
    
    [Column("content")]
    public string Content { get; init; }
    
    [Column("picture")]
    public string Picture { get; set; }
}