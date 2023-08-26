namespace Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public int Type { get; set; }
        public string? Category { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; } 
        
    }
}
