namespace Domain.Entities
{
    public class Dictionary
    {
        public int DictionaryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Word>? Words { get; set; }
        public List<Phrase>? Phrases { get; set; }
    }
}