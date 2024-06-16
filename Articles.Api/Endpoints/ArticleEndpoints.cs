using Articles.Api.Models;
using Articles.Api.Services;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Articles.Api.Endpoints
{
    public static class ArticleEndpoints
    {
        public static void MapArticleEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("articles");

            group.MapGet("", async (SqlConnectionFactory sqlConnectionFactory) =>
            {
                using var connection = sqlConnectionFactory.Create();

                const string sql = "SELECT * FROM Article";

                var articles = await connection.QueryAsync<Article>(sql);

                return Results.Ok(articles);
            });

            group.MapPost("", async (Article article, SqlConnectionFactory sqlConnectionFactory) =>
            {
                using var connection = sqlConnectionFactory.Create();

                const string sql = """
                INSERT INTO Article (Id, Title, Price, CreatedOn)
                VALUES (@Id, @Title, @Price, @CreatedOn)
                """;

                await connection.ExecuteAsync(sql, article);
                return Results.Ok();
            });

            group.MapPut("{id}", async(int id, Article article, SqlConnectionFactory sqlConnectionFactory) =>
            {
                using var connection = sqlConnectionFactory.Create();

                article.Id = id;

                const string sql = """
                UPDATE Article
                SET Title = @Title, 
                    Price = @Price, 
                    CreatedOn = @CreatedOn
                WHERE Id =  @Id
                """;

                await connection.ExecuteAsync(sql, article); 

                return Results.NoContent();
            });

            group.MapDelete("{id}", async(int id, SqlConnectionFactory sqlConnectionFactory) =>
            {
                using var connection = sqlConnectionFactory.Create();

                const string sql = "DELETE FROM Article WHERE Id = @ArticleId";

                await connection.ExecuteAsync(sql, new { ArticleId = id });

                return Results.NoContent();
            });
        }
    }
}
