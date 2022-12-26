

using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem_Final.Model;
using UniversityManagementSystem_Final.Repositories;
using UniversityManagementSystem_Final.ViewModels;

namespace UniversityManagementSystem_Final.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SemesterController : ControllerBase
    {

        private readonly UniversityManagementSystemDbContext _dbcontext;

        private readonly IGenericRepository<Semester> _semesterRepository;

        public SemesterController(IGenericRepository<Semester> semesterRepository,
            UniversityManagementSystemDbContext dbcontext)
        {
            _semesterRepository = semesterRepository;

            _dbcontext = dbcontext;

        }
        /// <summary>
        /// Get List Of Semester
        /// </summary>
        /// <returns>returns semester list</returns>
     
        [HttpGet]
        public async Task<IEnumerable<SemesterModel>> GetAllSemesters()
        {
            var semesters = await _semesterRepository.GetAllAsync(null);

            return semesters.Select(x => new SemesterModel
            {
                Name = x.Name,
                AvaliableGPA = x.AvailableGPA,
                Year = x.Year,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Schedules = x.Schedules,
                Departments = x.Departments,
                Students = x.Students,

            });
        }

        /// <summary>
        /// Get Semester By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>semester by its id</returns>
       
        [HttpGet("{id}")]
        public async Task<ActionResult<SemesterModel>> GetSemester(int id)
        {
            var semester = await _dbcontext.Semesters.FindAsync(id);

            return Ok(semester);
        }

       /// <summary>
       /// Insert Semester
       /// </summary>
       /// <param name="semester"></param>
       /// <returns>ok when inserted</returns>
        [HttpPost]
        public async Task AddSemester(SemesterModel semester)
        {
            await _semesterRepository.AddAsync(new Semester
            {
                Year = semester.Year,
                Name = semester.Name,
                AvailableGPA = semester.AvaliableGPA,
                StartDate = semester.StartDate,
                EndDate = semester.EndDate,

            });
            await _semesterRepository.SaveAsync();
        }

        /// <summary>
        /// Edit Semester By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sem"></param>
        /// <returns>ok when edited</returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> EditSemester(int id, SemesterModel s)
        {
            var semester = await _dbcontext.Semesters.FindAsync(id);
            if (SemesterExists(id))
            {

                if (s.Name != "string")
                {
                    semester.Name = s.Name;
                }
                else
                {
                    semester.Name = semester.Name;
                }

                if (s.AvaliableGPA != 0)
                {
                    semester.AvailableGPA = s.AvaliableGPA;
                }
                else
                {
                    semester.AvailableGPA = semester.AvailableGPA;
                }
                if (s.Year != 0)
                {
                    semester.Year = s.Year;
                }
                else
                {
                    semester.Year = semester.Year;
                }

                if (s.EndDate != DateTime.Now)
                {
                    semester.EndDate = s.EndDate;
                }
                else
                {
                    semester.EndDate = semester.EndDate;
                }

                if (s.StartDate != DateTime.Now)
                {
                    semester.StartDate = s.StartDate;
                }
                else
                {
                    semester.StartDate = semester.StartDate;
                }
                _dbcontext.Semesters.Update(semester);
                await _dbcontext.SaveChangesAsync();

            }
            return NoContent();
        }

        private bool SemesterExists(int id)
        {
            return _dbcontext.Semesters.Any(e => e.Id == id);
        }


        /// <summary>
        /// 1 წლის ცხრილი დეპარტამენტების მიხედვით.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet("{year}")]
        public async Task<ActionResult<SemesterModel>> GetSemesterbyYear(int year)
        {
            List<Semester> semesterByYear = new List<Semester>();
            semesterByYear = GetSemIdsByYear(year);
            var semester = new Semester();
            foreach (var i in semesterByYear)
            {
                semester = await _dbcontext.Semesters.FindAsync(i.Id);
            }

            var sy = semesterByYear.Select(x => new SemesterModel
            {

                Year = x.Year,
                Schedules = GetSchedsBySemesterID(x.Id),
                Departments = GetDepsBySemesterID(x.Id),
            });

            return Ok(sy);
        }

        private List<Department> GetDepsBySemesterID(int? id)
        {
            var x = _dbcontext.Departments.Where(y => y.SemesterId == id).ToList();
            return x;
        }

        private List<Schedule> GetSchedsBySemesterID(int? id)
        {
            var x = _dbcontext.Schedules.Where(y => y.SemesterId == id).ToList();
            return x;
        }


        private List<Semester> GetSemIdsByYear(int? year)
        {
            var x = _dbcontext.Semesters.Where(y => y.Year == year).ToList();

            return x;
        }



        private Department GetDepsByStudentID(int studentId)
        {
            Department x = _dbcontext.Departments.FirstOrDefault(y => y.Students.Any(k => k.Id == studentId));

            return x;
        }

        private Student GetStudentBySemesterID(int semesterId)
        {
            Student x = _dbcontext.Students.FirstOrDefault(y => y.SemesterId == semesterId);
            return x;
        }

        private List<int> GetStudIdBySemesterID(int semesterId)
        {
            var x = _dbcontext.Students.Where(y => y.SemesterId == semesterId).ToList();
            List<int> result = new List<int>();
            foreach (var i in x)
            {
                result.Add(i.Id);
            }
            return result;
        }

        private List<int> GetSubjectsIdByStudentID(int studentId)
        {
            var x = _dbcontext.StudentSubjects.Where(y => y.StudentId == studentId).ToList();
            List<int> ints = new List<int>();
            foreach (var i in x)
            {
                ints.Add(i.Id);
            }

            return ints;

        }

        private bool FailedStudent(int subjectId)
        {
            Subject x = _dbcontext.Subjects.FirstOrDefault(c => c.Id == subjectId);
            StudentSubject y = _dbcontext.StudentSubjects.FirstOrDefault(x => x.SubjectId == subjectId);
            if (y.Point < x.LowerBound)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

      /// <summary>
      /// ჩაჭრილი სტუდენტები დეპარტამენტების მიხედვით
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>


        [HttpGet("{id}")]
        public async Task<ActionResult<SemesterModel>> GetFailedStudentsBySemesterId(int id)
        {
            var studentsIds = GetStudIdBySemesterID(id);
            List<int> subjectIds = new List<int>();
            List<List<int>> subjectIdsS = new List<List<int>>();
            foreach (int student in studentsIds)
            {
                subjectIds = GetSubjectsIdByStudentID(student);
                subjectIdsS.Add(subjectIds);
            }
            List<bool> subjects = new List<bool>();

            foreach (var subject in subjectIdsS)
            {
                foreach (var sub in subject)
                {
                    subjects.Add(FailedStudent(sub));
                }
            }
            return Ok(subjects);
        }




        /// <summary>
        /// Delete Semester By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ok when deleted</returns>


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemester(int id)
        {
            var semester = await _dbcontext.Semesters.FindAsync(id);
            if (semester == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            _dbcontext.Semesters.Remove(semester);
            await _dbcontext.SaveChangesAsync();

            return NoContent();
        }

    }
}