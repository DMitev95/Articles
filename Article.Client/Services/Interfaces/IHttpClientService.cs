namespace Article.Client.Services.Interfaces
{
    public interface IHttpClientService
    {
        Task<T> GetAsync<T>(string uri);

        Task PutAsync(string uri, object value);
    }
}
