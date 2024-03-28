using Dapper;
using Domain.Models;
using Npgsql;

namespace Infrastracture.Services;

public class TeacherService : ITeacherService
{
    private readonly string _connectionString =
        "Server=localhost;Port=5432;Database=dapper_db;User Id=postgres;Password=12345";
    public List<Teacher> GetTeachers()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"Select * from teachers";
            var result = connection.Query<Teacher>(sql);
            return result.ToList();
        }
    }

    public Teacher GetTeacherById(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"Select * from teachers where id = {@id}";
            var result = connection.QueryFirstOrDefault<Teacher>(sql);
            return result;
        }
    }

    public string AddTeacher(Teacher teacher)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"Insert into teachers(fullname,subject,experience)" +
                      $"values ('{teacher.fullname}','{teacher.subject}',{teacher.experience})";
            var result = connection.Execute(sql);
            if (result > 0) return "Teacher successfully added";
            return "Failed to add teacher";
        }
    }

    public string UpdateTeacher(Teacher teacher)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        { 
            var sql = $"Update teachers Set fullname = '{teacher.fullname}',subject = '{teacher.subject}',experience = {teacher.experience} where id = {teacher.id}";
            var result = connection.Execute(sql);
            if (result > 0) return "Teacher successfully updated";
            return "Failed to update teacher";
        }
    }

    public string DeleteTeacher(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"Delete * from teachers where id = {@id}";
            var result = connection.Execute(sql);
            if (result > 0) return "Teacher successfully deleted";
            return "Failed to delete teacher";
        }
    }
}