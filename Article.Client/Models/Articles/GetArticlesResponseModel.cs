namespace Article.Client.Models.Articles
{
    public class GetArticlesResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
