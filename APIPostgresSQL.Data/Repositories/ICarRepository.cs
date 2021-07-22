using APIPostgresSQL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIPostgresSQL.Data.Repositories
{
    public  interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetCarDetails(int carId);
        Task<bool> InsertCar(Car car);
        Task<bool> UpdateCar(Car car);
        Task<bool> DeleteCar(Car car);


    }
}
