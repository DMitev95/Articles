using Article.Client.Models.Articles;
using Article.Client.Services.Interfaces;

namespace Article.Client.Services
{
    public class ArticleClientService : IArticleService
    {
        private readonly IHttpClientService httpClient;

        public ArticleClientService(IHttpClientService httpClient)
            => this.httpClient = httpClient;

        public async Task<List<GetArticlesResponseModel>> GetArticlesAsync()
            => await httpClient.GetAsync<List<GetArticlesResponseModel>>("");

        public async Task UpdateAsync(int id, EditArticleRequestModel request)
            => await httpClient.PutAsync($"articles/{id}", request);

    }
}
