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
    public class TrialFormController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TrialFormController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TrialForm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrialForm>>> GetTrialForm()
        {
          if (_context.TrialForm == null)
          {
              return NotFound();
          }
          
          var result = await _context.TrialForm.ToListAsync();
            
          HttpContext.Response.Headers.Add("X-Total-Count", result.Count.ToString());

          return Ok(result);
        }

        // GET: api/TrialForm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrialForm>> GetTrialForm(int id)
        {
          if (_context.TrialForm == null)
          {
              return NotFound();
          }
            var trialForm = await _context.TrialForm.FindAsync(id);

            if (trialForm == null)
            {
                return NotFound();
            }

            return trialForm;
        }

        // PUT: api/TrialForm/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrialForm(int id, TrialForm trialForm)
        {
            if (id != trialForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(trialForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrialFormExists(id))
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

        // POST: api/TrialForm
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrialForm>> PostTrialForm(TrialForm trialForm)
        {
          if (_context.TrialForm == null)
          {
              return Problem("Entity set 'ApplicationDbContext.TrialForm'  is null.");
          }
            _context.TrialForm.Add(trialForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrialForm", new { id = trialForm.Id }, trialForm);
        }

        // DELETE: api/TrialForm/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrialForm(int id)
        {
            if (_context.TrialForm == null)
            {
                return NotFound();
            }
            var trialForm = await _context.TrialForm.FindAsync(id);
            if (trialForm == null)
            {
                return NotFound();
            }

            _context.TrialForm.Remove(trialForm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrialFormExists(int id)
        {
            return (_context.TrialForm?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
