using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using ShopApplication.Contexts;
using ShopApplication.Repository;
using ShopApplication.Services;

namespace ShopApplication
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region AzureKeyVault
            var keyVaultName = "keyvault-aswathi";
            var kvUri = $"https://{keyVaultName}.vault.azure.net";
            const string secretName = "ConnectionString";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            var secret = await client.GetSecretAsync(secretName);
            var connectionString = secret.Value.Value;
            #endregion

            #region contexts
            builder.Services.AddDbContext<ShopContext>(options =>
                options.UseSqlServer(connectionString));
            #endregion

            builder.Services.AddScoped<IRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
