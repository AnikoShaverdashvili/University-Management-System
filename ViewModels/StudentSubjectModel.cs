using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.ViewModels
{
    public class StudentSubjectModel
    {
        
        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int Point { get; set; }
    }
}
