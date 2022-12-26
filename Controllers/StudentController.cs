using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UniversityManagementSystem_Final.Model;
using UniversityManagementSystem_Final.Repositories;
using UniversityManagementSystem_Final.ViewModels;

namespace UniversityManagementSystem_Final.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]


    public class StudentController : ControllerBase
    {

        private readonly UniversityManagementSystemDbContext _dbcontext;

        private readonly IGenericRepository<Student> _studentRepository;


        public StudentController(IGenericRepository<Student> studentRepository,
            UniversityManagementSystemDbContext dbcontext)
        {
            _studentRepository = studentRepository;

            _dbcontext = dbcontext;

        }

        /// <summary>
        /// Get Students List
        /// </summary>
        /// <returns>students list</returns>
        [HttpGet]
        public async Task<IEnumerable<StudentModel>> GetAllStudents()
        {

            Expression<Func<Student, object>> includes = express => express.Semester;
            Expression<Func<Student, object>> includes2 = express2 => express2.Address;
            Expression<Func<Student, object>> includes3 = express3 => express3.Department;
            Expression<Func<Student, object>> includes4 = express4 => express4.StudentSubjects;
            var students = await _studentRepository.GetAllAsync(null, new[] { includes, includes2, includes3, includes4 });

            return students.Select(x => new StudentModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                PersonalId = x.PersonalId,
                StartYear = x.StartYear,
                SemesterId = x.SemesterId,
                AddressId = x.AddressId,
                DepartmentId = x.DepartmentId,
                StudentSubjects = x.StudentSubjects

            });
        }
        /// <summary>
        /// Get Student By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ok when returned</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudent(int id)
        {
            var student = await _dbcontext.Students.FindAsync(id);

            if (student == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            return Ok(student);
        }

        /// <summary>
        /// Insert Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns>ok when inserted</returns>
        [HttpPost]
        public async Task AddStudent(StudentModel student)
        {
            await _studentRepository.AddAsync(new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                PersonalId = student.PersonalId,
                StartYear = student.StartYear,
                SemesterId = student.SemesterId,
                AddressId = student.AddressId,
                DepartmentId = student.DepartmentId,
            });
            await _studentRepository.SaveAsync();
        }

        /// <summary>
        /// Edir student By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stud"></param>
        /// <returns>ok when edited</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudent(int id, StudentModel stud)
        {
            var student = await _dbcontext.Students.FindAsync(id);

            if (stud.FirstName != "string")
            {
                student.FirstName = stud.FirstName;
            }
            else
            {
                student.FirstName = student.FirstName;
            }
            if (stud.LastName != "string")
            {
                student.LastName = stud.LastName;
            }
            else
            {
                student.LastName = student.LastName;
            }
            if (stud.PersonalId != "string")
            {
                student.PersonalId = stud.PersonalId;
            }
            else
            {
                student.PersonalId = student.PersonalId;
            }

            if (stud.StartYear != 0)
            {

                student.PersonalId = stud.PersonalId;
            }
            else
            {
                student.PersonalId = student.PersonalId;

            }

            if (stud.SemesterId != 0)
            {
                student.SemesterId = stud.SemesterId;
            }
            else
            {
                student.SemesterId = student.SemesterId;
            }
            if (stud.AddressId != 0)
            {
                student.AddressId = stud.AddressId;
            }
            else
            {
                student.AddressId = student.AddressId;
            }
            if (stud.DepartmentId != 0)
            {
                student.DepartmentId = stud.DepartmentId;
            }
            else
            {
                student.DepartmentId = student.DepartmentId;
            }
            _dbcontext.Students.Update(student);
            await _dbcontext.SaveChangesAsync();
            return Ok();


        }
/// <summary>
/// Detele Student By Id
/// </summary>
/// <param name="id"></param>
/// <returns>ok shen deleted</returns>


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _dbcontext.Students.FindAsync(id);
            _dbcontext.Students.Remove(student);
            await _dbcontext.SaveChangesAsync();
            return NoContent();
        }


    }
}
