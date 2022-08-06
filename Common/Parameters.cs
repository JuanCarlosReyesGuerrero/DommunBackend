using Microsoft.Extensions.Configuration;

namespace Common
{
    public class Parameters
    {
        private readonly IConfiguration configuration;

        public Parameters(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        public string cadenaConexion()
        {
            string ConnectionString = configuration["ConnectionStrings:DefaultConnection"];
            return ConnectionString;
        }
    }
}
