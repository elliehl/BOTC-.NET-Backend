using System;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
namespace BOTC.Data
{
	public class Context: IContext
	{
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public Context(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("DefaultConnection");
        }

        public IDbConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
	}

	public interface IContext
    {
        IDbConnection GetConnection();
    }   
}



