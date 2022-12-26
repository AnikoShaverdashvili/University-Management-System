using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using UniversityManagementSystem_Final.Model;
using UniversityManagementSystem_Final.Repositories;
using UniversityManagementSystem_Final.ViewModels;

namespace UniversityManagementSystem_Final.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentSubjectController : ControllerBase
    {

        private readonly UniversityManagementSystemDbContext _dbcontext;

        private readonly IGenericRepository<StudentSubject> _studentSubjectRepository;

        public StudentSubjectController(IGenericRepository<StudentSubject> studentSubjectRepository,
            UniversityManagementSystemDbContext dbcontext)
        {
            _studentSubjectRepository = studentSubjectRepository;

            _dbcontext = dbcontext;

        }

        /// <summary>
        /// Get StudentSubject
        /// </summary>
        /// <returns>sss</returns>
        [HttpGet]
        public async Task<IEnumerable<StudentSubjectModel>> GetAllStudentSubjects()
        {

            Expression<Func<StudentSubject, object>> includes = exp => exp.Student;
            Expression<Func<StudentSubject, object>> includes2 = exp2 => exp2.Subject;

            var studentsSubjects = await _studentSubjectRepository.GetAllAsync(null, new[] { includes, includes2 });
            var a = studentsSubjects.Count<StudentSubject>();

            Console.WriteLine(a);
            return studentsSubjects.Select(x => new StudentSubjectModel
            {
                Point = x.Point,
                StudentId = x.StudentId,
                SubjectId = x.SubjectId,

            });
        }

        /// <summary>
        /// Get StudentSubject By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentSubjectModel>> GetStudentSubject(int id)
        {
            var studentSubject = await _dbcontext.StudentSubjects.FindAsync(id);

            if (studentSubject == null)
            {
                return StatusCode(500);
            }

            return Ok(studentSubject);
        }


        private int? GetStudentMaxNumberOnSubject(int? id)
        {
            var x = _dbcontext.Subjects.First(c => c.Id == id);
            var y = x.MaxNumberOfStudents;
            return y;
        }

        private int? CountStudentsWithSameSubject(int? id)
        {
            var x = _dbcontext.StudentSubjects.Where(c => c.SubjectId == id);
            var y = x.Count();
            return y;
        }

        /// <summary>
        /// Insert StudentSubject
        /// </summary>
        /// <param name="studentSubject"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddStudentSubjectMax(StudentSubjectModel studentSubject)
        {
            await _studentSubjectRepository.AddAsync(new StudentSubject
            {
                Point = studentSubject.Point,
                StudentId = studentSubject.StudentId,
                SubjectId = (int)studentSubject.SubjectId
            });


            int? curentNumberOfStudents = CountStudentsWithSameSubject(studentSubject?.SubjectId);
            int? MaxNumberOfStudents = GetStudentMaxNumberOnSubject(studentSubject?.SubjectId);
            if (curentNumberOfStudents >= MaxNumberOfStudents)
            {
                return StatusCode(500);
            }
            else { await _studentSubjectRepository.SaveAsync(); }
            return NoContent();
        }

        /// <summary>
        /// Edit StudentSubject
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studS"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudentSubject(int id, StudentSubjectModel studS)
        {
            var studentSubject = await _dbcontext.StudentSubjects.FindAsync(id);

            if (studS.StudentId != 0)
            {
                studentSubject.StudentId = studS.StudentId;
            }
            else
            {
                studentSubject.StudentId = studentSubject.StudentId;
            }
            if (studS.SubjectId != 0)
            {
                studentSubject.SubjectId = studS.StudentId;
            }
            else
            {
                studentSubject.SubjectId = studentSubject.SubjectId;
            }

            _dbcontext.StudentSubjects.Update(studentSubject);
            await _dbcontext.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete StudentSubject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentSubject(int id)
        {
            var studentSubject = await _dbcontext.StudentSubjects.FindAsync(id);
            _dbcontext.StudentSubjects.Remove(studentSubject);
            await _dbcontext.SaveChangesAsync();

            return NoContent();
        }

    }
}