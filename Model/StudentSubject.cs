namespace UniversityManagementSystem_Final.Model
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int Point { get; set; }
        public int SubjectId { get; set; } 
        public Subject Subject { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
