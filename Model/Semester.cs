namespace UniversityManagementSystem_Final.Model
{
    public class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }

        public int AvailableGPA { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Balance> Balance { get; set; }

    }
}
