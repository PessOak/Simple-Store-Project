
//Classe responsavel por configurar e gerenciar a conexão com o banco de dados MySQL.

using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Data;

namespace SimpleStore.Web.Data
{
    public class MySqlContext : DbContext
    {
        private readonly string _connectionString;

        // O construtor recebe a configuração para pegar a string de conexão
        public MySqlContext(IConfiguration configuration)
        {
            // Obtém a string de conexão do arquivo appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Método para criar e retornar uma conexão com o MySQL
        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}