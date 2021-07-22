using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPostgresSQL.Data
{
   public class PostgresSQLConfiguration
    {
        public string ConnectionString { get; set; }
        public PostgresSQLConfiguration(string connectionString) => ConnectionString = connectionString;
    }
}
