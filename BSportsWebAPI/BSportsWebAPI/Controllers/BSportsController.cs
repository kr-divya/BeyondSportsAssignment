using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BSportsWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSportsWebAPI.Controllers
{
    [Route("api/bsports")]
    [ApiController]
    public class BSportsController : ControllerBase
    {

        private readonly BSportsContext _context;
        //private readonly BSportsContext _contextitem;

        public BSportsController(BSportsContext context)
        {
            _context = context;

            if (_context.BSportsItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.BSportsItems.Add(new BSportsItem { Team = "Juventus", Name = "Cristiano Ronaldo", Details = "Left Winger", Height = "1.87m", DateofBirth = "Feb 05 1985" });
                _context.BSportsItems.Add(new BSportsItem { Team = "Juventus", Name = "Federico Bernardeschi", Details = "Right Winger", Height = "1.83m", DateofBirth = "Feb 16 1994" });
                _context.BSportsItems.Add(new BSportsItem { Team = "Juventus", Name = "Douglas Costa", Details = "Right Winger", Height = "1.72m", DateofBirth = "Sep 14 1990" });
                _context.BSportsItems.Add(new BSportsItem { Team = "Juventus", Name = "Juan Cuadrado", Details = "Right Winger", Height = "1.79m", DateofBirth = "May 26 1988" });
                _context.BSportsItems.Add(new BSportsItem { Team = "Juventus", Name = "Paulo Dybala", Details = "Second Striker", Height = "1.77m", DateofBirth = "Nov 15 1993" });
                _context.BSportsItems.Add(new BSportsItem { Team = "Juventus", Name = "Gonzalo Higuaín", Details = "Centre Forward", Height = "1.84m", DateofBirth = "Dec 10 1987" });
                _context.BSportsItems.Add(new BSportsItem { Team = "Juventus", Name = "Miralem Pjanic", Details = "Central Midfield", Height = "1.80m", DateofBirth = "Apr 02 1990" });
                _context.BSportsItems.Add(new BSportsItem { Team = "Ajax Amsterdam", Name = "Donny van de Beek", Details = "Attacking Midfield", Height = "1.84m", DateofBirth = "Apr 18, 1997" });
                _context.BSportsItems.Add(new BSportsItem { Team = "Ajax Amsterdam", Name = "Andre Onana", Details = "Goalkeeper", Height = "1.90m", DateofBirth = "Apr 02, 1996 " });
                _context.BSportsItems.Add(new BSportsItem { Team = "Ajax Amsterdam", Name = "Daley Blind", Details = "Centre Back", Height = "1.80m", DateofBirth = "Mar 09, 1990 " });
                
                _context.SaveChanges();
            }
        }

        // GET: api/BSports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BSportsItem>>> GetBSportsItem()
        {
            return await _context.BSportsItems.ToListAsync();
        }

        // GET: api/BSports/2
        [HttpGet("{id}")]
        public async Task<ActionResult<BSportsItem>> GetBSportsItems(int id)
        {
            
            var bsportsItem = await _context.BSportsItems.FindAsync(id);

            if (bsportsItem == null)
            {
                return NotFound();
            }

            return bsportsItem;
        }

        // GET: api/BSports/team=Juventus
        [HttpGet("Team={team}")]
        public async Task<ActionResult<IEnumerable>> GetTeamPlayers(string team)
        {
            var teamplayers = _context.BSportsItems.AsQueryable();

            if (team != null)
            {
                teamplayers = _context.BSportsItems.Where(i => i.Team == team.ToString());
            }

            if (teamplayers == null)
            {
                return NotFound();
            }

            return await teamplayers.ToListAsync();
        }

        // POST: api/BSports
        [HttpPost]
        public async Task<ActionResult<BSportsItem>> PostBSportsItem(BSportsItem item)
        {
            _context.BSportsItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBSportsItems), new { id = item.Id }, item);
        }
        
        // PUT: api/BSports/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBSportsItem(int id, BSportsItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/BSports/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBSportsItem(int id)
        {
            var BSportsItem = await _context.BSportsItems.FindAsync(id);

            if (BSportsItem == null)
            {
                return NotFound();
            }

            _context.BSportsItems.Remove(BSportsItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
