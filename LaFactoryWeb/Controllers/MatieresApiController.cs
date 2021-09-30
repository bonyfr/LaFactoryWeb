using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaFactoryWeb.Context;
using LaFactoryWeb.Models;

namespace LaFactoryWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatieresApiController : ControllerBase
    {
        private readonly FormationContext _context;

        public MatieresApiController(FormationContext context)
        {
            _context = context;
        }

        // GET: api/MatieresApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matiere>>> GetMatieres()
        {
            return await _context.Matieres.ToListAsync();
        }

        // GET: api/MatieresApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matiere>> GetMatiere(int id)
        {
            var matiere = await _context.Matieres.FindAsync(id);

            if (matiere == null)
            {
                return NotFound();
            }

            return matiere;
        }

        // PUT: api/MatieresApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatiere(int id, Matiere matiere)
        {
            if (id != matiere.Id)
            {
                return BadRequest();
            }

            _context.Entry(matiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatiereExists(id))
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

        // POST: api/MatieresApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Matiere>> PostMatiere(Matiere matiere)
        {
            _context.Matieres.Add(matiere);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatiere", new { id = matiere.Id }, matiere);
        }

        // DELETE: api/MatieresApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatiere(int id)
        {
            var matiere = await _context.Matieres.FindAsync(id);
            if (matiere == null)
            {
                return NotFound();
            }

            _context.Matieres.Remove(matiere);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatiereExists(int id)
        {
            return _context.Matieres.Any(e => e.Id == id);
        }
    }
}
