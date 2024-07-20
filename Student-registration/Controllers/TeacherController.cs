
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

using Student_registration.Models;

namespace Student_registration.Controllers
{
    public class TeacherController : Controller
    {
        private readonly string connectionString;
        public TeacherController()
        {
            connectionString = "server=localhost;port=3306;uid=root;pwd=fintechtik@2024;database=student";
        }
        [HttpGet]
        public IActionResult Teachers()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Teachers(teachermodel teachers)
        {
            if (ModelState.IsValid)
            {
                Generic te = new Generic();
                bool result = te.InsertStudent(teachers);
                if (result == true) {
                    ViewBag.Message = "teachers inserted successfuly!";
                    return View(teachers);

                }
                else
                {
                    ViewBag.Message = "Failed";
                    return View(teachers);
                }


            }
            return View(teachers);
        }
        [HttpGet]
        public IActionResult getteachers()
        {
            Generic obj=new Generic();
            var teache = obj.Getteachers();
            return View(teache);
        }



        // Edit 
        [HttpGet]
        public IActionResult Edit(int teacherid)
        {
            Generic obj = new Generic();
            var teacher = obj.GetTeacherById(teacherid);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
        [HttpPost]
        public IActionResult Edit(teachermodel teacher)
        {
            if (ModelState.IsValid)
            {
                Generic obj = new Generic();
                bool result = obj.UpdateTeacher(teacher);
                if (result)
                {
                    TempData["updated"] = "Teacher updated successfully!";
                    return RedirectToAction("GetTeachers");
                }
                else
                {
                    ViewBag.message = "Failed";
                }
            }
            return View(teacher);
        }

    }
}

