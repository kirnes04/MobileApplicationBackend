using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileApplicationBackend.Context;
using MobileApplicationBackend.Models;

namespace MobileApplicationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentParticipantConrtoller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TournamentParticipantConrtoller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TournamentParticipantConrtoller
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentParticipants>>> GetTournamentParticipants()
        {
          if (_context.TournamentParticipants == null)
          {
              return NotFound();
          }
            return await _context.TournamentParticipants.ToListAsync();
        }

        // GET: api/TournamentParticipantConrtoller/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentParticipants>> GetTournamentParticipants(int id)
        {
          if (_context.TournamentParticipants == null)
          {
              return NotFound();
          }
            var tournamentParticipants = await _context.TournamentParticipants.FindAsync(id);

            if (tournamentParticipants == null)
            {
                return NotFound();
            }

            return tournamentParticipants;
        }

        // PUT: api/TournamentParticipantConrtoller/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournamentParticipants(int id, TournamentParticipants tournamentParticipants)
        {
            if (id != tournamentParticipants.Id)
            {
                return BadRequest();
            }

            _context.Entry(tournamentParticipants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentParticipantsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TournamentParticipantConrtoller
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TournamentParticipants>> PostTournamentParticipants(TournamentParticipants tournamentParticipants)
        {
          if (_context.TournamentParticipants == null)
          {
              return Problem("Entity set 'ApplicationDbContext.TournamentParticipants'  is null.");
          }
            _context.TournamentParticipants.Add(tournamentParticipants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTournamentParticipants", new { id = tournamentParticipants.Id }, tournamentParticipants);
        }

        // DELETE: api/TournamentParticipantConrtoller/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournamentParticipants(int id)
        {
            if (_context.TournamentParticipants == null)
            {
                return NotFound();
            }
            var tournamentParticipants = await _context.TournamentParticipants.FindAsync(id);
            if (tournamentParticipants == null)
            {
                return NotFound();
            }

            _context.TournamentParticipants.Remove(tournamentParticipants);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TournamentParticipantsExists(int id)
        {
            return (_context.TournamentParticipants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
