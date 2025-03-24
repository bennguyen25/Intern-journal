using Microsoft.AspNetCore.Mvc;
using InternJournalAPI.Models;

namespace InternJournalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntryController : ControllerBase
    {
        // In-memory list to simulate a database
        private static List<Entry> entries = new List<Entry>
        {
            new Entry
            {
                Id = 1,
                Title = "First Entry",
                Body = "Setting up the API project!",
                Mood = "Excited",
                Tags = new List<string> { "setup", "api" },
                Date = DateTime.Now
            }
        };

        [HttpGet]
        public ActionResult<List<Entry>> GetAllEntries()
        {
            return Ok(entries);
        }
    }
}
