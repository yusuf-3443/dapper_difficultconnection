using Domain.Models;
using Infrastracture.Services;

var carservice = new CarService();
var car = new Car()
{
  id = 1,
  model  = "audi",
  color = "blue",
  engine = 2,
};
// Console.WriteLine(carservice.DeleteCar(2));

var groupservice = new GroupService();
var group = new Group()
{
coursename = "Java",
teacher = "Saidali Mirzo",
price = 800
};
// Console.WriteLine(groupservice.AddGroup(group));

 // var result = groupservice.GetGroups();
 // foreach (var r in result)
 // {
 //     Console.WriteLine(r.id +" " + r.coursename +" "+ r.teacher + " " +r.price );
 // }
 
 var teacherservice = new TeacherService();
 var teacher = new Teacher()
 {
     fullname = "Said hotam",
     subject = "chemistry",
     experience = 7
 };

 // var teacherid = teacherservice.GetTeacherById(1);
 // Console.WriteLine(teacherid.id +" "+ teacherid.fullname +" "+ teacherid.subject +" "+ teacherid.experience);
 //
 // Console.WriteLine(teacherservice.UpdateTeacher(teacher));
