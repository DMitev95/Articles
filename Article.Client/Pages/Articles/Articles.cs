using Article.Client.Models.Articles;
using Article.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Article.Client.Pages.Articles
{
    public partial class Articles
    {
        [Inject]
        private IArticleService ArticleService { get; set; }

        private List<GetArticlesResponseModel> Article { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var getArticlesResponse = await ArticleService.GetArticlesAsync();

                foreach (var article in getArticlesResponse)
                {
                    Article.Add(new GetArticlesResponseModel
                    {
                        Id = article.Id,
                        Title = article.Title,
                        Price = article.Price,
                    });
                }
            }
            catch
            {
                throw new ArgumentException("Something whent wrong!");
            }
        }

        private async void UpdateAsync(int id, string name, decimal price)
        {
            var request = new EditArticleRequestModel
            {
                Title = name,
                Price = price
            };

            try
            {
                await ArticleService.UpdateAsync(id, request);
                StateHasChanged();
            }
            catch
            {
                throw new ArgumentException("Something whent wrong!");
            }
        }
    }
}
