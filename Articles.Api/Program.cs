using Articles.Api.Endpoints;
using Articles.Api.Services;

namespace Articles.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton(serviceProvider =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ApplicationException("The connection string is null!");
                return  new SqlConnectionFactory(connectionString);
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapArticleEndpoints();

            app.Run();
        }
    }
}
