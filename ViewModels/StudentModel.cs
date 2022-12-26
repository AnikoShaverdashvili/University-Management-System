using System.ComponentModel.DataAnnotations.Schema;
using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.ViewModels
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public int StartYear { get; set; }
        public int? SemesterId { get; set; }
        public Semester? Semester { get; set; }
        public int DepartmentId { get; set; }
       
        public Department Department { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }
        public ICollection<Balance> Balance { get; set; }

    }
}
