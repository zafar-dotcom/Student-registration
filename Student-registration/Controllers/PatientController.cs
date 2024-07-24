using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Student_registration.Models;


namespace Student_registration.Controllers
{

    public class PatientController : Controller
    {
        private readonly string connectionString;
        public PatientController()
        {
            connectionString = "server=localhost;port=3306;uid=root;pwd=fintechtik@2024;database=student";
        }

        [HttpGet]
        public IActionResult Patients()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Patients(Patient patients)
        {
            Generic generic = new Generic();
            bool result = generic.InsertPatient(patients);
            if (result == true)
            {
                ViewBag.meassage = "patients inserted successfuly!";
                return View(patients);

            }
            else
            {
                ViewBag.message = "Failed";
                return View(patients);
            }

            return View(patients);
        }
      
        [HttpGet]
        public IActionResult getpatient()
        {
            Generic patient = new Generic();//create generic object
            var patients = patient.GetPatients();
            return View(patients);//return view get patient
        }
        //Edit patient
        [HttpGet]
        public IActionResult EditPatient(int PatientId)
        {
            Generic obj = new Generic();
            var patients= obj.GetPatientById(PatientId);
            if (patients == null)
            {
                return NotFound();
            }
            return View(patients);

        }
        
        [HttpPost]
        public IActionResult EditPatient(Patient patients)
        {
            if (ModelState.IsValid)
            {
                Generic obj = new Generic();
                bool result = obj.UpdatePatient(patients);
                if (result)
                {
                    TempData["updated"] = "Patient updated successfully!";
                    return RedirectToAction("GetPatients");
                }
                else
                {
                    ViewBag.message = "Failed";
                }
            }
            return View(patients);
        }





















    }
    }


