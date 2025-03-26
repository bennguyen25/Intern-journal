using Microsoft.AspNetCore.Mvc;
using InternJournalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InternJournalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntryController : ControllerBase
    {
        // In-memory list to simulate a database
        // private static List<Entry> entries = new List<Entry>
        // {
        //     new Entry
        //     {
        //         Id = 1,
        //         Title = "First Entry",
        //         Body = "Setting up the API project!",
        //         Mood = "Excited",
        //         Tags = new List<string> { "setup", "api" },
        //         Date = DateTime.Now
        //     }
        // };
        private readonly JournalContext _context;

        public EntryController(JournalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Entry>>> GetAllEntries()
        {
            var entries = await _context.Entries.ToListAsync();
            return Ok(entries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entry>> GetEntryById(int id)
        {
            var entry = await _context.Entries.FindAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        // POST new entry
        [HttpPost]
        public async Task<ActionResult<Entry>> CreateEntry([FromBody] Entry newEntry)
        {
            newEntry.Date = DateTime.Now;

            _context.Entries.Add(newEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEntryById), new { id = newEntry.Id }, newEntry);
        }

        // PUT update existing entry
        [HttpPut("{id}")]
        public async Task<ActionResult<Entry>> UpdateEntry(int id, [FromBody] Entry updatedEntry)
        {
            var existingEntry = await _context.Entries.FindAsync(id);

            if (existingEntry == null)
            {
                return NotFound();
            }

            existingEntry.Title = updatedEntry.Title;
            existingEntry.Body = updatedEntry.Body;
            existingEntry.Mood = updatedEntry.Mood;
            existingEntry.Tags = updatedEntry.Tags;
            existingEntry.Date = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(existingEntry);
        }

        // DELETE entry
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry(int id)
        {
            var existingEntry = await _context.Entries.FindAsync(id);

            if (existingEntry == null)
            {
                return NotFound();
            }

            _context.Entries.Remove(existingEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
