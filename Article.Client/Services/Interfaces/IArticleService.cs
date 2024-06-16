using Article.Client.Models.Articles;
using System.Net.Http;

namespace Article.Client.Services.Interfaces
{
    public interface IArticleService
    {
        public Task<List<GetArticlesResponseModel>> GetArticlesAsync();

        public Task UpdateAsync(int id, EditArticleRequestModel request);
    }
}
