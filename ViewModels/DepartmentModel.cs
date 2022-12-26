using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.ViewModels
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxNumberStudents { get; set; }
        public int CuttentAmount { get; set; }
        public int? SemesterId { get; set; }
        public Semester? Semester { get; set; }
        public ICollection<Teacher>? Teachers { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}
