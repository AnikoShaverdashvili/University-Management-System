using UniversityManagementSystem_Final.Model;   

namespace UniversityManagementSystem_Final.Model
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

    }
}
