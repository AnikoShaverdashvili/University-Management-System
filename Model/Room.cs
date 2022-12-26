using System.Diagnostics.Eventing.Reader;
using UniversityManagementSystem_Final.Model;


namespace UniversityManagementSystem_Final.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsFree { get; set; }
        public int MaxNumberOfStudents { get; set; }
    }
}
