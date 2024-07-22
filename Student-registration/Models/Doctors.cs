namespace Student_registration.Models
{
    public class Doctors
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string FatherName { get; set; }    
        public string Adress { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Country { get; set; }   
        public string Hospitalname { get; set; } 
    }
}
