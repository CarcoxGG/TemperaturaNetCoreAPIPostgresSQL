using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperaturaNetCoreAPIPostgresSQL.Data
{
    public class PostgreSQLConfiguration
    {
        
        public PostgreSQLConfiguration(string connectionString) => ConnectionString = connectionString;
        public string ConnectionString { get; set; }
    }
}
