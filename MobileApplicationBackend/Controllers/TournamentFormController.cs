using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileApplicationBackend.Context;
using MobileApplicationBackend.Models;

namespace MobileApplicationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentFormController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TournamentFormController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TournamentForm
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<TournamentForm>>> GetTournamentForm()
        {
          if (_context.TournamentForm == null)
          {
              return NotFound();
          }
          
          var result = await _context.TournamentForm.ToListAsync();
            
          HttpContext.Response.Headers.Add("X-Total-Count", result.Count.ToString());

          return Ok(result);
        }

        // GET: api/TournamentForm/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<TournamentForm>> GetTournamentForm(int id)
        {
          if (_context.TournamentForm == null)
          {
              return NotFound();
          }
            var tournamentForm = await _context.TournamentForm.FindAsync(id);

            if (tournamentForm == null)
            {
                return NotFound();
            }

            return tournamentForm;
        }

        // PUT: api/TournamentForm/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutTournamentForm(int id, TournamentForm tournamentForm)
        {
            if (id != tournamentForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(tournamentForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentFormExists(id))
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

        // POST: api/TournamentForm
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TournamentForm>> PostTournamentForm(TournamentForm tournamentForm)
        {
          if (_context.TournamentForm == null)
          {
              return Problem("Entity set 'ApplicationDbContext.TournamentForm'  is null.");
          }
            _context.TournamentForm.Add(tournamentForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTournamentForm", new { id = tournamentForm.Id }, tournamentForm);
        }

        // DELETE: api/TournamentForm/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteTournamentForm(int id)
        {
            if (_context.TournamentForm == null)
            {
                return NotFound();
            }
            var tournamentForm = await _context.TournamentForm.FindAsync(id);
            if (tournamentForm == null)
            {
                return NotFound();
            }

            _context.TournamentForm.Remove(tournamentForm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TournamentFormExists(int id)
        {
            return (_context.TournamentForm?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
