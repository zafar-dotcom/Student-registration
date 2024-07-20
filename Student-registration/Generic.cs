using MySql.Data.MySqlClient;
using Student_registration.Models;

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
                    string sqlQuery = "INSERT INTO Students (Fullname, Fathername, Email, Phone,Address,City,Rollnumber,Mrarks) " +
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
                        command.Parameters.AddWithValue("@Dob", teachers.Dob);


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
        public bool InsertPatient(Patient patients)
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
                                    Fullname = reader["Fullname"].ToString(),
                                    Fathername = reader["Fathername"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    City = reader["City"].ToString(),
                                    Rollno = reader["Rollnumber"].ToString(),
                                    Marks = reader["Mrarks"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["Mrarks"].ToString())
                                            ? float.Parse(reader["Mrarks"].ToString())
                                            : 0.0f // Default value if parsing fails
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
                    string sqlQuery = "SELECT * FROM Doctor WHERE DoctorId = @id";
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
                                    FullName = reader["FullName"].ToString(),
                                    FatherName = reader["FatherName"].ToString(),
                                    Adress = reader["Adress"].ToString(),
                                    City = reader["City"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Country = reader["Country"].ToString(),
                                    Hospitalname = reader["Hospitalname"].ToString(),

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
                                    teacherid =Convert.ToInt32(reader["TeacherId"]),
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

        #endregion  -----------Read ------------





        #region -----------Edit----------
        public bool UpdateTeacher(teachermodel teacher)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "UPDATE teachers SET FullName = @FullName, FatherName = @FatherName, Email = @Email, Phone = @Phone, Dob = @Dob WHERE TeacherId = @Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", teacher.FullName);
                cmd.Parameters.AddWithValue("@FatherName", teacher.FatherName);
                cmd.Parameters.AddWithValue("@Email", teacher.Email);
                cmd.Parameters.AddWithValue("@Phone", teacher.Phone);
                cmd.Parameters.AddWithValue("@Dob", teacher.Dob);
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
                        Dob = reader.GetDateTime(reader.GetOrdinal("Dob"))
                    };
                }
            }

            return teacher;
        }

        #endregion --------- Edit --------
    }
}
