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
                Generic generic = new Generic();    //create generic object
                bool result = generic.InsertStudent(doctors);    //
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
            Generic genric = new Generic();//create new generic object
            var doctor = genric.Getdoctors();
            return View(doctor);

        }

        
        [HttpGet]
        public IActionResult EditDoctor(int DoctorId)
        {
            Generic obj = new Generic();
            var doctors = obj.GetDoctorById(DoctorId);
            if (doctors == null)
            {
                return NotFound();
            }
            return View(doctors);
        }
        [HttpPost]
        public IActionResult EditDoctor(Doctors doctor)
        {
            if (ModelState.IsValid)
            {
                Generic obj = new Generic();
                bool result = obj.UpdateDoctor(doctor);
                if (result)
                {
                    TempData["updated"] = "Doctor updated successfully!";
                    return RedirectToAction("GetDoctor");
                }
                else
                {
                    ViewBag.message = "Failed";
                }
            }
            return View(doctor);
        }





    }
}

