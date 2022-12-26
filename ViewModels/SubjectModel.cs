using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.ViewModels
{
    public class SubjectModel
    {
        public int Credit { get; set; }
     
        public string Name { get; set; }
      
        public int LowerBound { get; set; }
      
        public int MaxNumberOfStudents { get; set; }

        public int MaxNumberOfTeachers { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<StudentSubject> StudentSubject { get; set; }
    }
}
