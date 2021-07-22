using APIPostgresSQL.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPostgresSQL.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private PostgresSQLConfiguration _connectionString;
        public CarRepository(PostgresSQLConfiguration connectioString) 
        { 
             _connectionString = connectioString; 
        }

        protected NpgsqlConnection dbConnection() 
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteCar(Car car)
        {
            var db = dbConnection();
            var sql = @" DELETE FROM  public.""Cars""
                          WHERE id=@Id) ";
            var result = await db.ExecuteAsync(sql, new { Id= car.Id });
            return result > 0;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            var db = dbConnection();
            var sql = @"SELECT id,model,make,color,year,doors,segment FROM public.""Cars"" ";
            return await db.QueryAsync<Car>(sql,new { });
        }

        public async Task<Car> GetCarDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id,model,make,color,year,doors,segment FROM public.""Cars"" WHERE id=@Id ";
            return await db.QueryFirstOrDefaultAsync<Car>(sql, new {Id=id });
        }

        public async Task<bool> InsertCar(Car car)
        {
            var db = dbConnection();
            var sql = @" INSERT INTO public.""Cars""
                          (model,make,color,year,doors,segment)
                         values(@Model,@Make,@Color,@Year,@Doors,@Segment) ";
            var result= await db.ExecuteAsync(sql, new { car.Model,car.Make,car.Color,car.Year,car.Doors,car.Segment});
            return result > 0;
        }

        public async Task<bool> UpdateCar(Car car)
        {
            var db = dbConnection();
            var sql = @" UPDATE public.""Cars""
                         SET  model=@Model,
                              make=@Make,
                              color=@Color,
                              year=@Year,
                              doors=@Doors,
                              segment=@Segment
                         WHERE id=@Id  ";
            var result = await db.ExecuteAsync(sql, new { car.Model, car.Make, car.Color, car.Year, car.Doors, car.Segment,car.Id });
            return result > 0;
        }
    }
}
