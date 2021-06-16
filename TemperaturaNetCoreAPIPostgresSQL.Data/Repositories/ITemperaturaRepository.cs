using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperaturaNetCoreAPIPostgresSQL.Model;

namespace TemperaturaNetCoreAPIPostgresSQL.Data.Repositories
{
    public interface ITemperaturaRepository
    {
        Task<IEnumerable<Temperatura>> GetAllTemps();
        Task<Temperatura> GetTempDetails(string ciudad);
        Task<bool> InsertTemp(Temperatura temp);
        Task<bool> UpdateTemp(Temperatura temp);
        Task<bool> DeleteTemp(Temperatura temp);
    }
}
