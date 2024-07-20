namespace Student_registration.Models
{
    public class teachermodel
    {
        public int teacherid { get; set; }
        public string  FullName { get; set; }
        public string  FatherName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; }
       public DateTime Dob { get; set; }
               
    }
}
