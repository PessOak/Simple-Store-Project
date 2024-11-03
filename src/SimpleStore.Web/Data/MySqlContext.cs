// Classe responsavel por configurar e gerenciar a conexão com o banco de dados MySQL.

using Microsoft.EntityFrameworkCore;

namespace SimpleStore.Web.Data
{
    public static class MySqlContext
    {
        public static void AddMySqlDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}