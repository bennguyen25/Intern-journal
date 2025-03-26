using Microsoft.EntityFrameworkCore;

namespace InternJournalAPI.Models
{
    public class JournalContext : DbContext
    {
        public JournalContext(DbContextOptions<JournalContext> options)
            : base(options)
        {
        }

        public DbSet<Entry> Entries { get; set; } = null!;
    }
}