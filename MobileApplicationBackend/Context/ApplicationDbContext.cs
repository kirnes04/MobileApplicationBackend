using Microsoft.EntityFrameworkCore;
using MobileApplicationBackend.Models;

namespace MobileApplicationBackend.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
        
    }
    public DbSet<News>? News { get; set; }
    
    public DbSet<Workout>? Workout { get; set; }
    
    public DbSet<MobileApplicationBackend.Models.Tournament>? Tournament { get; set; }
    
    public DbSet<MobileApplicationBackend.Models.Event>? Event { get; set; }
    
    public DbSet<MobileApplicationBackend.Models.Seminar>? Seminar { get; set; }
    
    public DbSet<MobileApplicationBackend.Models.User>? User { get; set; }
    
    public DbSet<MobileApplicationBackend.Models.TournamentParticipants>? TournamentParticipants { get; set; }
    
    public DbSet<MobileApplicationBackend.Models.Feedback>? Feedback { get; set; }
}