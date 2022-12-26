using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystem_Final.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public int StartYear { get; set; }
        public int? SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public Semester? Semester { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }
        public ICollection<Balance> Balance { get; set; }


    }
}
