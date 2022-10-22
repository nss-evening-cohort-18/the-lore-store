namespace backend.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? AuthorLastName { get; set; }
        public string? AuthorFirstName { get; set; }
        public string DatePublished { get; set; }
        public string Description { get; set; }
        public int IsFiction { get; set; }
        public string SubGenre { get; set; }
        public float Price { get; set; }
        public int InventoryQuantity { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
