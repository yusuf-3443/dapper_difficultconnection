using Dapper;
using Domain.Models;
using Npgsql;

namespace Infrastracture.Services;

public class CarService: ICarService
{
    private readonly string _connectionString =
        "Server=localhost;Port=5432;Database=dapper_db;User Id=postgres;Password=12345";
    public List<Car> GetCars()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = "Select * from cars";
            var result = connection.Query<Car>(sql);
            return result.ToList();
        }
    }

    public Car GetCarById(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"Select * from cars where id = {@id}";
            var result = connection.QueryFirstOrDefault<Car>(sql);
            return result;
        }
    }

    public string AddCar(Car car)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"Insert into cars(model,color,engine)" +
                      $"values ('{car.model}','{car.color}',{car.engine})";
            var result = connection.Execute(sql);
            if (result>0)
            {
                return $"Car successfully added";
            }

            return $"Failed to add car";
        }
    }

    public string UpdateCar(Car car)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"Update cars set model = '{car.model}', color = '{car.color}',engine = '{car.engine}' where id = {car.id}";
            var result = connection.Execute(sql);
            if (result>0)
            {
                return $"Car successfully updated";
            }

            return $"Failed to update car";
        }
    }

    public string DeleteCar(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"Delete from cars where cars.id = {@id}";
            var result = connection.Execute(sql);
            if (result>0)
            {
                return $"Car successfully deleted";
            }

            return $"Failed to delete car";
        }
    }
}