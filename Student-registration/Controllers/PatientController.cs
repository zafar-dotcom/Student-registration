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
        public IActionResult Patient(Patient patients)
        {
            Generic generic = new Generic();
            bool result = generic.InsertStudent(patients);
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
        }
      
        [HttpGet]
        public IActionResult getpatient()
        {
            Generic patients = new Generic();//create generic object
            var patient = patients.GetPatients();
            return View(patient);//return view get patient
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
                    TempData["updated"] = "Patients updated successfully!";
                    return RedirectToAction("Getpatient");
                }
                else
                {
                    ViewBag.message = "Failed";
                }
            }
            return View(patients);
        }
        //delete
        [HttpGet]
        public IActionResult Delete(int PatientId)
        {
            Generic dlt = new Generic();
            bool result = dlt.DeletePatient(PatientId);
            if (result)
            {
                TempData["Deleted"] = "Deleted sucessfully!";
                return RedirectToAction("getpatient");
            }
            else
            {
                TempData["Deleted"] = "Deleted Failed!";
                return RedirectToAction("getpatient");
            }

        }
    }
    }


