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

    public class TeacherController : ControllerBase
    {

        private readonly UniversityManagementSystemDbContext _dbcontext;

        private readonly IGenericRepository<Teacher> _teacherRepository;
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public TeacherController(IGenericRepository<Teacher> teacherRepository,
            UniversityManagementSystemDbContext dbcontext)
        {
            _teacherRepository = teacherRepository;

            _dbcontext = dbcontext;

        }
      
        /// <summary>
        /// Get Teacher List
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public async Task<IEnumerable<TeacherModel>> GetAllTeachers()
        {

            Expression<Func<Teacher, object>> includes = express => express.Subject;
            Expression<Func<Teacher, object>> includes2 = express2 => express2.Department;
            Expression<Func<Teacher, object>> includes3 = express3 => express3.Address;

            var teachers = await _teacherRepository.GetAllAsync(null, new[] { includes, includes2, includes3 });
            return teachers.Select(x => new TeacherModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PersonalId = x.PersonalId,
                SubjectId = x.SubjectId,
                DepartmentId = x.DepartmentId,
                AddressId = x.AddressId
            }) ;
        }

        /// <summary>
        /// Get Teacher Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherModel>> GetTeacher(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);

            return Ok(teacher);
        }

        /// <summary>
        /// Insert Teacher
        /// </summary>
        /// <param name="teachers"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> AddTeacherMaxSubj(List<TeacherModel> teachers)
        {
            foreach (var teacher in teachers)
            {
                await _teacherRepository.AddAsync(new Teacher
                {

                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    PersonalId = teacher.PersonalId,
                    SubjectId = teacher.SubjectId,
                    DepartmentId = teacher.DepartmentId,
                    AddressId = teacher.AddressId,
                });

                int? curentNumberOfTeachers = CountTeacherWithSameSubject(teacher?.SubjectId);
                int? MaxNumberOfTeachers = GetTeacherMaxNumberOnSubject(teacher?.SubjectId);
                if (curentNumberOfTeachers >= MaxNumberOfTeachers)
                {
                    return StatusCode(500);
                }
                else { await _teacherRepository.SaveAsync(); }

            }
            return Ok();


        }


        private int? GetTeacherMaxNumberOnSubject(int? id)
        {
            var x = _dbcontext.Subjects.First(c => c.Id == id);
            var y = x.MaxNumberOfTeachers;
            return y;
        }

        private int? CountTeacherWithSameSubject(int? id)
        {
            var x = _dbcontext.Teachers.Where(c => c.SubjectId == id);
            var y = x.Count();
            return y;
        }


        /// <summary>
        /// Edit Teacher
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teach"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTeacher(int id, TeacherModel teach)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
           
                if (teach.FirstName != "string")
                {
                    teacher.FirstName = teach.FirstName;
                }
                else
                {
                    teacher.FirstName = teacher.FirstName;
                }

                if (teach.LastName != "string")
                {
                    teacher.LastName = teach.LastName;
                }
                else
                {
                    teacher.LastName = teacher.LastName;
                }

                if (teach.PersonalId != "string")
                {   
                    teacher.PersonalId = teach.PersonalId;
                }
                else
                {
                    teacher.PersonalId = teacher.PersonalId;
                }


                if (teach.SubjectId != 0)
                {
                    teacher.SubjectId = teach.SubjectId;
                }
                else
                {
                    teacher.SubjectId = teacher.SubjectId;
                }

                if (teach.DepartmentId != 0)
                {
                    teacher.DepartmentId = teach.DepartmentId;
                }
                else
                {
                    teacher.DepartmentId = teacher.DepartmentId;
                }

                if (teach.AddressId != 0)
                {
                    teacher.AddressId = teach.AddressId;
                }
                else
                {
                    teacher.AddressId = teacher.AddressId;
                }

                _teacherRepository.Update(teacher);
                await _teacherRepository.SaveAsync();

            return Ok();
        }


        /// <summary>
        /// Delete Teacher By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            _teacherRepository.Delete2(teacher);
            await _teacherRepository.SaveAsync();

            return Ok();
        }




    }
}