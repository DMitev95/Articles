using Article.Client.Models.Articles;

namespace Article.Client.Services.Interfaces
{
    public interface IArticleService
    {
        public Task<List<GetArticlesResponseModel>> GetArticlesAsync();

        public Task UpdateAsync(int id, EditArticleRequestModel request);
    }
}
