using Domain.Models;

namespace Infrastracture.Services;

public interface ITeacherService
{
    List<Teacher> GetTeachers();
    Teacher GetTeacherById(int id);
    string AddTeacher(Teacher teacher);
    string UpdateTeacher(Teacher teacher);
    string DeleteTeacher(int id);
}