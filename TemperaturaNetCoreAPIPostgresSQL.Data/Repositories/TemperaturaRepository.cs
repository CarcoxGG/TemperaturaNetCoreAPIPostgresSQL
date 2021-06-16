using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperaturaNetCoreAPIPostgresSQL.Model;

namespace TemperaturaNetCoreAPIPostgresSQL.Data.Repositories
{
    public class TemperaturaRepository : ITemperaturaRepository
    {
        private PostgreSQLConfiguration _connectionString;

        public TemperaturaRepository(PostgreSQLConfiguration connectionString) 
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteTemp(Temperatura temp)
        {
            var db = dbConnection();

            var sql = @"
                            DELETE 
                            FROM public.temperaturas
                             WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { temp.Id });

            return result > 0;
        }

        public async Task<IEnumerable<Temperatura>> GetAllTemps()
        {
            var db = dbConnection();

            var sql = @"
                            SELECT *
                            FROM public.temperaturas";

            return await db.QueryAsync<Temperatura>(sql, new { });
        }

        public async Task<Temperatura> GetTempDetails(string ciudad)
        {
            var db = dbConnection();

            var sql = @"
                            SELECT *
                            FROM public.temperaturas WHERE ciudad = @Ciudad";

            return await db.QueryFirstOrDefaultAsync<Temperatura>(sql, new { Ciudad = ciudad });
        }

        public async Task<bool> InsertTemp(Temperatura temp)
        {
            var db = dbConnection();

            var sql = @"
                            INSERT INTO public.temperaturas (ciudad, fecha, temp)
                            VALUES (@Ciudad, @Fecha, @Temp)";

            var result = await db.ExecuteAsync(sql, new { temp.Ciudad, temp.Fecha, temp.Temp });

            return result > 0;
        }

        public async Task<bool> UpdateTemp(Temperatura temp)
        {
            var db = dbConnection();

            var sql = @"
                            UPDATE public.temperaturas
                            SET ciudad = @Ciudad, 
                                fecha = @Fecha, 
                                temp = @Temp
                            WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { temp.Ciudad, temp.Fecha, temp.Temp, temp.Id });

            return result > 0;
        }
    }
}
