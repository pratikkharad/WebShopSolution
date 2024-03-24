
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Shop.Infrastructure.DbContext
{
    /// <summary>
    /// Database connection string is created 
    /// </summary>
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionstring;

        public DapperDBContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.connectionstring = this._configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new System.Data.SqlClient.SqlConnection(connectionstring);
            await connection.OpenAsync();
            return connection;
        }
    }
}
