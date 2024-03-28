using Dapper;
using Domain.Models;
using Npgsql;

namespace Infrastracture.Services;

public class GroupService:IGroupService
{
    private readonly string _connectionString =
        "Server=localhost;Port=5432;Database=dapper_db;User Id=postgres;Password=12345";
    public List<Group> GetGroups()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = "Select * from Groups";
            var result = connection.Query<Group>(sql);
            return result.ToList();
        }
    }

    public Group GetGroupById(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = "Select * from groups where id = {@id}";
            var result = connection.QueryFirstOrDefault<Group>(sql);
            return result;
        }
    }

    public string AddGroup(Group group)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"Insert into groups(coursename,teacher,price)" +
                      $"values ('{group.coursename}','{group.teacher}',{group.price})";
            var result = connection.Execute(sql);
            if (result > 0) return "Group successfully added";
            return "Failed to add group";
        }
    }

    public string UpdateGroup(Group group)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql =
                $"Update groups set coursename = '{group.coursename}',teacher = '{group.teacher}',price = {group.price} where id = {group.id}";
            var result = connection.Execute(sql);
            if (result > 0) return "Group successfully updated";
            return "Failed to update group ";
        }
    }

    public string DeleteGroup(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"Delete * from groups where id = {@id}";
            var result = connection.Execute(sql);
            if (result > 0) return "Group successfully deleted";
            return "Failed to delete group";
        }
    }
}