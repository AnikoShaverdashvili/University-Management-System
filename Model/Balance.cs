using UniversityManagementSystem_Final.Model;

namespace UniversityManagementSystem_Final.Model
{
    public class Balance
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Debth { get; set; }
        public int? StudentId { get; set; }
        public Student Student { get; set; }
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

    }
}
