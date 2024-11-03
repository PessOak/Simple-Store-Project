using MySql.Data.MySqlClient;
using System.Data;

namespace SimpleStore.Web.Data
{
    public static class DapperConfiguration
    {
        public static void AddDapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDbConnection>(sp =>
                new MySqlConnection(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
