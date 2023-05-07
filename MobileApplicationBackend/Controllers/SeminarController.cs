using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileApplicationBackend.Context;
using MobileApplicationBackend.Models;
using Microsoft.AspNetCore.Authorization;

namespace MobileApplicationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SeminarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Seminar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seminar>>> GetSeminar()
        {
          if (_context.Seminar == null)
          {
              return NotFound();
          }
          
          var result = await _context.Seminar.ToListAsync();
            
          HttpContext.Response.Headers.Add("X-Total-Count", result.Count.ToString());

          return Ok(result);
        }

        // GET: api/Seminar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seminar>> GetSeminar(int id)
        {
          if (_context.Seminar == null)
          {
              return NotFound();
          }
            var seminar = await _context.Seminar.FindAsync(id);

            if (seminar == null)
            {
                return NotFound();
            }

            return seminar;
        }

        // PUT: api/Seminar/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutSeminar(int id, Seminar seminar)
        {
            if (id != seminar.Id)
            {
                return BadRequest();
            }

            _context.Entry(seminar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeminarExists(id))
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

        // POST: api/Seminar
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Seminar>> PostSeminar(Seminar seminar)
        {
            if (_context.Seminar is null)
            {
                return Problem("Entity set 'ApplicationDbContext.Seminar' is null.");
            }
            
            _context.Seminar.Add(seminar);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetSeminar", new { id = seminar.Id}, seminar);
        }

        // DELETE: api/Seminar/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteSeminar(int id)
        {
            if (_context.Seminar == null)
            {
                return NotFound();
            }
            var seminar = await _context.Seminar.FindAsync(id);
            if (seminar == null)
            {
                return NotFound();
            }

            _context.Seminar.Remove(seminar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeminarExists(int id)
        {
            return (_context.Seminar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
