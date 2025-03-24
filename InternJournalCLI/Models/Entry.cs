// namespace InternJournal.Models ensures the class is scoped logically and won’t conflict with other classes.
namespace InternJournal.Models
{
    public class Entry
    {
        // Each property has get; set; to allow it to be read and written.
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Mood { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Date { get; set; }

        public Entry()
        {
            // The constructor initializes Tags to avoid null reference errors and sets the date automatically.
            Tags = new List<string>();
            Date = DateTime.Now;
        }
    }
}