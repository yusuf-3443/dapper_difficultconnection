using Domain.Models;

namespace Infrastracture.Services;

public interface ICarService
{
    List<Car> GetCars();
    Car GetCarById(int id);
    string AddCar(Car car);
    string UpdateCar(Car car);
    string DeleteCar(int id);
}