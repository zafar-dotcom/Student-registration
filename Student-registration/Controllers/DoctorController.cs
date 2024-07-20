using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

using Student_registration.Models;
using System.Numerics;

namespace Student_registration.Controllers
{
    public class DoctorController : Controller
    {
        private readonly string connectionString;
        public DoctorController()
        {
            connectionString = "server=localhost;port=3306;uid=root;pwd=fintechtik@2024;database=student";
        }
        [HttpGet]
        public IActionResult Doctors()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Doctors(Doctors doctors)
        {
            if (ModelState.IsValid)
            {
                Generic generic = new Generic();
                bool result = generic.InsertStudent(doctors);
                if (result == true)
                {
                    ViewBag.meassage = "doctors inserted successfuly!";
                    return View(doctors);

                }
                else
                {
                    ViewBag.message = "Failed";
                    return View(doctors);
                }


            }
            return View(doctors);
        }
       
         [HttpGet]
        public IActionResult getDoctor()
        {
            Generic genric = new Generic();
            var doctor = genric.Getdoctors();
            return View(doctor);
        }


       




    }
}

