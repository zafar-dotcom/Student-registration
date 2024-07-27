
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
                Generic obj = new Generic();

                bool result = obj.InsertStudent(students);
                if (result)
                {
                    ViewBag.Message = "Student inserted successfully!";
                    return View(students);
                }
                else
                {
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
        [HttpGet]
        //EditStudent
        public IActionResult EditStudent(int StudentID)
        {
            Generic obj = new Generic();
            var Students = obj.GetStudentById(StudentID);
            if (Students == null)
            {
                return NotFound();
            }
            return View(Students);

        }

        [HttpPost]
        public IActionResult EditStudent(StudentFoms students)
        {
            if (ModelState.IsValid)
            {
                Generic obj = new Generic();
                bool result = obj.UpdateStudent(students);
                if (result)
                {
                    TempData["updated"] = "Students updated successfully!";
                    return RedirectToAction("GetStudents");//redirect mean to get updated list
                }
                else
                {
                    ViewBag.message = "Failed";
                }
            }
            return View(students);
        }
        //delete
        [HttpGet]
        public IActionResult Delete(int StudentID)
        {
            Generic dlt = new Generic();
            bool result = dlt.DeleteStudent(StudentID);
            if (result)
            {
                TempData["Deleted"] = "Deleted sucessfully!";
                return RedirectToAction("GetStudents");
            }
            else
            {
                TempData["Deleted"] = "Deleted Failed!";
                return RedirectToAction("GetStudents");
            }

        }
    }
}
