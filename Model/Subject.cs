namespace UniversityManagementSystem_Final.Model
{
    public class Subject
    {
        public int Id { get; set; }
        public int Credit { get; set; }
        public string Name { get; set; } = null!;
        public int LowerBound { get; set; }
        public int ScheduleId { get; set; }
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public int MaxNumberOfStudents { get; set; }
        public int MaxNumberOfTeachers { get; set; }
        public int StudentSubject { get;  set; }
    }
}
