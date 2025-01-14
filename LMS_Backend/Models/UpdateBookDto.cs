namespace LMS_Backend.Models
{
    public class UpdateBookDto
    {
        public required string Name { get; set; }
        public required string Author { get; set; }
        public required string Description { get; set; }
    }
}
