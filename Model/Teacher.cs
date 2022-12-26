using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }


    }
}
