using System.Data.SqlClient;

namespace WebMVC_CRUD.Data {
    public class DbConnection {
        private string cadenaSQL = string.Empty;

        public DbConnection() { 
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json")
                                                    .Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:DefaultConnection")
                               .Value;
        }

        public string GetCadenaSQL() { 
            return cadenaSQL;
        }
    }
}
