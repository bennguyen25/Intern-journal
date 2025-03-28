using System.ComponentModel.DataAnnotations;

namespace InternJournalAPI.Models
{
    public class Entry
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Body { get; set; } = string.Empty;

        [Required]
        public string Mood { get; set; } = string.Empty;

        public List<string> Tags { get; set; } = new();

        public DateTime Date { get; set; }
    }
}
