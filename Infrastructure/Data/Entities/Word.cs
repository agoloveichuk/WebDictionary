namespace Domain.Entities
{
    public class Word
    {
        public int WordId { get; set; }
        public int? DictionaryId { get; set; }
        public string? EnWord { get; set; }
        public string? UaWord { get; set; }
        public string? Definition { get; set; }
        public Dictionary? Dictionary { get; set; }
    }
}
