namespace MusicWorksAPI.Models
{
    public class Work
    {
        public int Id { get; set; }

        public required string Title { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public Category? Category { get; set; }
           
        public string Instrumentation { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int PublicationYear { get; set; }

    }
}
