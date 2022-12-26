using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }


    }
}