namespace InternJournalAPI.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Mood { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Date { get; set; }

        public Entry()
        {
            Tags = new List<string>();
            Date = DateTime.Now;
        }
    }
}