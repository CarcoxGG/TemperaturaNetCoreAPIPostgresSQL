using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperaturaNetCoreAPIPostgresSQL.Model
{
    public class Temperatura
    {
        public int Id { get; set; }
        public string Ciudad { get; set; }
        public int Temp { get; set; }
        public DateTime Fecha { get; set; }
    }
}
