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
            Generic pa = new Generic();
            bool result = pa.InsertPatient(patients);
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
            var patients = GetPatients();
            return View(patients);
        }








      
        public List<Patient> GetPatients()
        {
            var patients = new List<Patient>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Patient";
                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                patients.Add(new Patient
                                {
                                    PatientId = reader["patient_id"].ToString(),
                                    FullName = reader["fullname"].ToString(),
                                    FatherName = reader["fathername"].ToString(),
                                    BedNumber = reader["bednumber"].ToString(),
                                    Phone = reader["phone"].ToString(),
                                    City = reader["city"].ToString(),
                                    Hospital = reader["hospital"].ToString(),
                                    DateOfBirth = Convert.ToDateTime(reader["dob"]),
                                    Address = reader["adress"].ToString(),
                                    EmergencyContact = reader["emergencycontact"].ToString(),
                                    MedicalHistory = reader["medicalhistory"].ToString(),
                                    BloodType = reader["bloodtype"].ToString(),
                                    Allergies = reader["allergies"].ToString()
                                });
                            }
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception)
            {
                // Handle exception
            }
            return patients;
        }












    }
    }


