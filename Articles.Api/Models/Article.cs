namespace Articles.Api.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        //Here we can add and UpdateOn so we can see when specific article is updated.

        //We can add and and IsDeleted boolean.

    }
}
