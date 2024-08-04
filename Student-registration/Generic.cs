using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using Student_registration.Models;
using System.Data;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Policy;

namespace Student_registration
{
    public class Generic
    {
        private readonly string connectionString;
        public Generic()
        {
            connectionString = "server=localhost;port=3306;uid=root;pwd=fintechtik@2024;database=student";

        }

        // CRUD create Read ,update ,delete
        #region  --------------Create ------------------
        public bool InsertStudent(Doctors doctors)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "INSERT INTO Doctor (FullName, FatherName, Adress,City,Phone,Emial,Country,Hospital_Name) " +
                  "VALUES (@FullName, @FatherName,@Adress,@City,@Phone,@Emial,@Country,@Hospital_Name)";
                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", doctors.FullName);
                        command.Parameters.AddWithValue("@FatherName", doctors.FullName);
                        command.Parameters.AddWithValue("@Adress", doctors.Adress);
                        command.Parameters.AddWithValue("@City", doctors.City);
                        command.Parameters.AddWithValue("@Phone", doctors.Phone);
                        command.Parameters.AddWithValue("@Emial", doctors.Email);
                        command.Parameters.AddWithValue("@Country", doctors.Country);
                        command.Parameters.AddWithValue("Hospital_Name", doctors.Hospitalname);


                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            return true; // Replace with appropriate action and controller
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool InsertStudent(StudentFoms student)
        {
            StudentFoms obj = new StudentFoms();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "INSERT INTO Students (Fullname, Fathername, Email, Phone,  Address,City,Rollnumber,Mrarks) " +
                  "VALUES (@Fullname, @Fathername, @Email, @Phone,@Address,@City,@Rollnumber,@Mrarks)";
                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Fullname", student.Fullname);
                        command.Parameters.AddWithValue("@Fathername", student.Fathername);
                        command.Parameters.AddWithValue("@Email", student.Email);
                        command.Parameters.AddWithValue("@Phone", student.Phone);
                        command.Parameters.AddWithValue("@Address", student.Address);
                        command.Parameters.AddWithValue("@City", student.City);
                        command.Parameters.AddWithValue("@Rollnumber", student.Rollno);
                        command.Parameters.AddWithValue("@Mrarks", student.Marks);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            return true; // Replace with appropriate action and controller
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool InsertStudent(teachermodel teachers)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "INSERT INTO Teachers (FullName, FatherName, Email, Phone,Dob) " +
                  "VALUES (@FullName, @FatherName, @Email, @Phone,@Dob)";
                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", teachers.FullName);
                        command.Parameters.AddWithValue("@FatherName", teachers.FatherName);
                        command.Parameters.AddWithValue("@Email", teachers.Email);
                        command.Parameters.AddWithValue("@Phone", teachers.Phone);
                        command.Parameters.AddWithValue("@dob", teachers.Dob);


                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            return true; // Replace with appropriate action and controller
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool InsertStudent(Patient patients)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "INSERT INTO Patient (fullname , fathername, bednumber,phone,city,hospital,dob,adress,emergencycontact,medicalhistory,bloodtype,allergies) " +
                  "VALUES (@fullname, @fathername,@bednumber,@phone,@city,@hospital,@dob,@adress,@emergencycontact,@medicalhistory,@bloodtype, @allergies)";
                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@fullname", patients.FullName);
                        command.Parameters.AddWithValue("@fathername", patients.FatherName);
                        command.Parameters.AddWithValue("@bednumber", patients.BedNumber);
                        command.Parameters.AddWithValue("@phone", patients.Phone);
                        command.Parameters.AddWithValue("@city", patients.City);
                        command.Parameters.AddWithValue("@hospital", patients.Hospital);
                        command.Parameters.AddWithValue("@dob", patients.DateOfBirth);
                        command.Parameters.AddWithValue("@adress", patients.Address);
                        command.Parameters.AddWithValue("@emergencycontact", patients.EmergencyContact);
                        command.Parameters.AddWithValue("@medicalhistory", patients.MedicalHistory);
                        command.Parameters.AddWithValue("@bloodtype", patients.BloodType);
                        command.Parameters.AddWithValue("@allergies", patients.Allergies);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            return true; // Replace with appropriate action and controller
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool Register(Rgistermodel models,string Hashpassword)
        {
           try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "INSERT INTO users (firstname , lastname, password,email,phone,gender) " +
                    "VALUES (@firstname, @lastname,@password,@email,@phone,@gender)";
                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@firstname", models.FirstName);
                        command.Parameters.AddWithValue("@lastname", models.LastName);
                        command.Parameters.AddWithValue("@password",Hashpassword);
                        command.Parameters.AddWithValue("@email", models.Email);
                        command.Parameters.AddWithValue("@phone", models.Phone);
                        command.Parameters.AddWithValue("@gender", models.Gender);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            return true; // Replace with appropriate action and controller
                        }
                        else
                        {
                            return false;
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        public int UserAlreadyExit(string Email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT COUNT(*) FROM users WHERE email =@Email";
                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Email",Email);
                        connection.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();

                        if (count > 0)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public int userexistornot(Signin modl)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT COUNT(*) FROM users WHERE email =@email and password =  @password";
                    
                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Email", modl.Email);
                        command.Parameters.AddWithValue("@password", modl.Password);
                        connection.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();

                        if (count > 0)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
       

        public int UserExistOrNot(Signin modl)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM users WHERE email = @Email";

                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", modl.Email);
                   
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                                if (common.Security.Verify(modl.Password, dataTable.Rows[0]["password"].ToString()))
                                    {
                                    return 1;
                                 }
                                else
                                {
                                    return 0;
                                }
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    #endregion ---------- Create -----------------

    #region -----------------Read ----------------
    public List<StudentFoms> Getstudent()
        {
            List<StudentFoms> students = new List<StudentFoms>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Students";
                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentFoms obj = new StudentFoms
                                {
                                    StudentId = Convert.ToInt32(reader["StudentID"].ToString()),
                                    Fullname = reader["Fullname"] != DBNull.Value ? reader["Fullname"].ToString() : string.Empty,
                                    Fathername = reader["Fathername"] != DBNull.Value ? reader["Fathername"].ToString() : string.Empty,
                                    Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty,
                                    Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : string.Empty,
                                    Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : string.Empty,
                                    City = reader["City"] != DBNull.Value ? reader["City"].ToString() : string.Empty,
                                    Rollno = reader["Rollnumber"] != DBNull.Value ? reader["Rollnumber"].ToString() : string.Empty,
                                    Marks = reader["Mrarks"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Mrarks"].ToString())
                                            ? float.Parse(reader["Mrarks"].ToString()) : 0.0f, // Default value if parsing fails
                                };
                                students.Add(obj);
                            }
                        }
                    }
                }
                return students;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw;
            }
        }
        public Doctors GetDoctorById(int id)
        {
            Doctors doctor = null;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Doctor WHERE TeacherId = @id";
                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                doctor = new Doctors
                                {
                                    DoctorId = Convert.ToInt32(reader["TeacherId"].ToString()),
                                    FullName = reader["FullName"].ToString(),
                                    FatherName = reader["FatherNAME"].ToString(),
                                    Adress = reader["Adress"].ToString(),
                                    City = reader["City"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Email = reader["Emial"].ToString(),
                                    Country = reader["Country"].ToString(),
                                    Hospitalname = reader["Hospital_Name"].ToString(),

                                };
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
            return doctor;
        }
        public List<teachermodel> Getteachers()
        {
            List<teachermodel> teachers = new List<teachermodel>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Teachers";
                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                teachermodel obj = new teachermodel
                                {
                                    teacherid = Convert.ToInt32(reader["TeacherId"]),
                                    FullName = reader["FullName"].ToString(),
                                    FatherName = reader["FatherName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    

                                };
                                teachers.Add(obj);

                            }

                        }
                    }
                }
                return teachers;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Doctors> Getdoctors()
        {
            List<Doctors> doctors = new List<Doctors>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Doctor";
                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Doctors obj = new Doctors
                                {
                                    DoctorId = reader.GetInt32(reader.GetOrdinal("TeacherId")),
                                    FullName = reader["FullName"].ToString(),
                                    FatherName = reader["FatherNAME"].ToString(),
                                    Adress = reader["Adress"].ToString(),
                                    City = reader["City"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Email = reader["Emial"].ToString(),
                                    Country = reader["Country"].ToString(),
                                    Hospitalname = reader["Hospital_Name"].ToString(),

                                };
                                doctors.Add(obj);
                            }

                        }
                    }
                }
                return doctors;
            }
            catch (Exception)
            {
                throw;
            }
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
                                    PatientId = reader.GetInt32(reader.GetOrdinal("patient_id")),
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

        #endregion  -----------Read ------------

        #region -----------Edit----------
        public bool UpdateTeacher(teachermodel teacher)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "UPDATE teachers SET FullName = @FullName, FatherName = @FatherName, " +
                    "Email = @Email, Phone = @Phone, Dob = @Dob WHERE TeacherId = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", teacher.FullName);
                cmd.Parameters.AddWithValue("@FatherName", teacher.FatherName);
                cmd.Parameters.AddWithValue("@Email", teacher.Email);
                cmd.Parameters.AddWithValue("@Phone", teacher.Phone);
                cmd.Parameters.AddWithValue("@dob", teacher.Dob);
                cmd.Parameters.AddWithValue("@Id", teacher.teacherid); // Assuming Id is the primary key

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public teachermodel GetTeacherById(int id)
        {
            teachermodel teacher = null;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM teachers WHERE TeacherId = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    teacher = new teachermodel
                    {
                        teacherid = reader.GetInt32(reader.GetOrdinal("TeacherId")),
                        FullName = reader["FullName"].ToString(),
                        FatherName = reader["FatherName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Dob = Convert.ToDateTime(reader["dob"].ToString()),
                    };
                }
            }

            return teacher;
        }

        #endregion --------- Edit --------

        #region-------------Edit Doctor------
        public bool UpdateDoctor(Doctors doctors)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Doctor SET FullName =@FullName, FatherNAME = @FatherNAME," +
                    " Adress = @Adress, City = @City, Phone = @Phone,Emial = @Emial," +
                    "Country = @Country,Hospital_Name = @Hospital_Name  WHERE TeacherId = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", doctors.FullName);
                cmd.Parameters.AddWithValue("@FatherNAME", doctors.FatherName);
                cmd.Parameters.AddWithValue("@Adress", doctors.Adress);
                cmd.Parameters.AddWithValue("@City", doctors.City);
                cmd.Parameters.AddWithValue("@Phone", doctors.Phone);
                cmd.Parameters.AddWithValue("@Emial", doctors.Email);
                cmd.Parameters.AddWithValue("@Country", doctors.Country);
                cmd.Parameters.AddWithValue("@Hospital_Name", doctors.Hospitalname);// Assuming Id is the primary key
                cmd.Parameters.AddWithValue("@Id", doctors.DoctorId);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >0)
                { 
                return true;
                }
                else
                        {
                    return false;
                }
              
            }
        }

        public Doctors GetDoctorsById(int id)
        {
            Doctors doctors = null;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Doctor WHERE DoctorId ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    doctors = new Doctors
                    {
                        DoctorId = reader.GetInt32(reader.GetOrdinal("DoctorId")),
                        FullName = reader["FullName"].ToString(),
                        FatherName = reader["FatherNAME"].ToString(),
                        Adress = reader["Adress"].ToString(),
                        City = reader["City"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Emial"].ToString(),
                        Country = reader["Country"].ToString(),
                        Hospitalname = reader["Hospital_Name"].ToString(),

                    };
                }
            }

            return doctors;
        }

        #endregion-----Doctor---------
        #region----------Edit patient---------
        public bool UpdatePatient(Patient patients) // return type is bool - true or false
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "UPDATE Patient SET fullname =@fullname, fathername = @fathername," +
                    " bednumber = @bednumber, phone = @phone, city = @city,hospital = @hospital," +
                    "dob = @dob,adress =@adress,emergencycontact = @emergencycontact,medicalhistory=@medicalhistory ,bloodtype = @bloodtype,allergies = @allergies WHERE patient_id = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fullname", patients.FullName);
                cmd.Parameters.AddWithValue("@fathername", patients.FatherName);
                cmd.Parameters.AddWithValue("@bednumber", patients.BedNumber);
                cmd.Parameters.AddWithValue("@phone", patients.Phone);
                cmd.Parameters.AddWithValue("@city", patients.City);
                cmd.Parameters.AddWithValue("@hospital", patients.Hospital);
                cmd.Parameters.AddWithValue("@dob", patients.DateOfBirth);
                cmd.Parameters.AddWithValue("@adress", patients.Address);// Assuming Id is the primary key
                cmd.Parameters.AddWithValue("@emergencycontact", patients.EmergencyContact);
                cmd.Parameters.AddWithValue("@medicalhistory", patients.MedicalHistory);
                cmd.Parameters.AddWithValue("@bloodtype", patients.BloodType);
                cmd.Parameters.AddWithValue("@allergies", patients.Allergies);
                cmd.Parameters.AddWithValue("@Id", patients.PatientId);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public Patient GetPatientById(int PatientId)
        {
            Patient patients = null;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM patient WHERE patient_id = @id";
                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", PatientId);
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                patients = new Patient
                                {
                                    PatientId = Convert.ToInt32(reader["patient_id"].ToString()),
                                    FullName = reader["fullname"].ToString(),
                                    FatherName = reader["fathername"].ToString(),
                                    BedNumber = reader["bednumber"].ToString(),
                                    Phone = reader["phone"].ToString(),
                                    City = reader["city"].ToString(),
                                    Hospital = reader["hospital"].ToString(),
                                    DateOfBirth = Convert.ToDateTime(reader["dob"].ToString()),
                                    Address = reader["adress"].ToString(),
                                    EmergencyContact = reader["emergencycontact"].ToString(),
                                    MedicalHistory = reader["medicalhistory"].ToString(),
                                    BloodType = reader["bloodtype"].ToString(),
                                    Allergies = reader["allergies"].ToString(),

                                };
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
        #endregion---------Patient------------
        #region------------Student-------------
        public bool UpdateStudent(StudentFoms student) // return type is bool - true or false
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query  = "UPDATE students SET Fullname =@Fullname, Fathername = @Fathername," +
                    " Email = @Email, Phone = @Phone," +
                    "Address = @Address,City =@City, Rollnumber=@Rollnumber,Mrarks = @Mrarks WHERE StudentID = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Fullname", student.Fullname);
                cmd.Parameters.AddWithValue("@Fathername", student.Fathername);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Phone", student.Phone);      
                cmd.Parameters.AddWithValue("@Address", student.Address);
                cmd.Parameters.AddWithValue("@City", student.City);
                cmd.Parameters.AddWithValue("@Rollnumber", student.Rollno);// Assuming Id is the primary key
                cmd.Parameters.AddWithValue("@Mrarks", student.Marks);
                cmd.Parameters.AddWithValue("@Id", student.StudentId);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public StudentFoms GetStudentById(int StudentID)
        {
            StudentFoms student = null;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Students WHERE StudentID = @id";
                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", StudentID);
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                student = new StudentFoms
                                {
                                    StudentId = Convert.ToInt32(reader["StudentID"]),
                                    Fullname = reader["Fullname"].ToString(),
                                    Fathername = reader["Fathername"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : string.Empty,
                                    City = reader["City"] != DBNull.Value ? reader["City"].ToString() : string.Empty,
                                    Rollno = reader["Rollnumber"] != DBNull.Value ? reader["Rollnumber"].ToString() : string.Empty,
                                    Marks = Convert.ToInt32(reader["Mrarks"]),
                                };
                            }
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return student;
        }
        #endregion---------Student-------------

        #region----------Delete Teacher-----------
          public int DeleteTeacher(int teachers) // return type is bool - true or false
      
        {
            try
            {

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    string query = "Delete from Teachers where TeacherId =@Id";// sql Querry
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", teachers);
                    conn.Open();

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }
        
        }

        #endregion---------Delete----------
        #region----------Delete student--------
        public bool DeleteStudent(int students) // return type is bool - true or false

        {
            try
            {

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    string query = "Delete from Students where StudentID =@Id";// sql Querry
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", students);
                    conn.Open();

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion---------delete---------
        #region----------delete patient-----
        public bool DeletePatient(int patients) // return type is bool - true or false

        {
            try
            {

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    string query = "Delete from Patient where patient_id =@Id";// sql Querry
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", patients);
                    conn.Open();

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion----------delete---------- 
        #region--------Delete Doctor-----------
        public string DeleteDoctor(int DoctorId) // return type is bool - true or false

        {
            try
            {

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    string query = "Delete from Doctor where TeacherId =@Id";// sql Querry
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", DoctorId);
                    conn.Open();

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return "Done";
                    }
                    else
                    {
                        return "no";
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion------delete----------
      

       
    }

}