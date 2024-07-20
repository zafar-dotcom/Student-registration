
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Student_registration.Models;
using System.Reflection.Metadata.Ecma335;


namespace Student_registration.Controllers
{ 
    public class StudentController : Controller
    {
    private readonly string connectionString;
    public StudentController()
    {
        connectionString = "server=localhost;port=3306;uid=root;pwd=fintechtik@2024;database=student";
    }
    [HttpGet]
    public IActionResult Students()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Students(StudentFoms students)
    {
        if (ModelState.IsValid)
        {
                Generic  obj= new Generic();

                bool result = obj.InsertStudent(students);
            if (result)
            {
                ViewBag.Message = "Student inserted successfully!";
                return View(students);
            }
            else {
                ViewBag.Message = "Failed!";
                return View(students);
            }
        }

        return View(students);
    }
   
    [HttpGet]
    public IActionResult GetStudents()
    {
            Generic genric = new Generic();
        var students = genric.Getstudent();
        return View(students);
    }

  }
}
