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

    public class SubjectController : ControllerBase
    {

        private readonly UniversityManagementSystemDbContext _dbcontext;

        private readonly IGenericRepository<Subject> _subjectRepository;

        public SubjectController(IGenericRepository<Subject> subjectRepository,
            UniversityManagementSystemDbContext dbcontext)
        {
            _subjectRepository = subjectRepository;

            _dbcontext = dbcontext;

        }


        /// <summary>
        /// Get Subject 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<SubjectModel>> GetAllSubjects()
        {

           
            Expression<Func<Subject, object>> includes = exp => exp.Teachers;
            Expression<Func<Subject, object>> includes3 = exp3 => exp3.StudentSubjects;

            var subjects = await _subjectRepository.GetAllAsync(null, new[] { includes, includes3 });
         
            return subjects.Select(x => new SubjectModel
            {
                Credit = x.Credit,
                Name = x.Name,
                LowerBound = x.LowerBound,
                MaxNumberOfStudents = x.MaxNumberOfStudents,
                MaxNumberOfTeachers = x.MaxNumberOfTeachers,
                Teachers = x.Teachers,
                StudentSubject = (ICollection<StudentSubject>)x.StudentSubjects
            });
        }

       
        /// <summary>
        /// Get Subject By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectModel>> GetSubject(int id)
        {
            var subject = await _dbcontext.Subjects.FindAsync(id);
            return Ok(subject);
        }

        /// <summary>
        /// Insert Subject 
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task AddSubject(SubjectModel subject)
        {
            await _subjectRepository.AddAsync(new Subject
            {
                Credit = subject.Credit,
                Name = subject.Name,
                LowerBound = subject.LowerBound,
                MaxNumberOfStudents = subject.MaxNumberOfStudents,
                MaxNumberOfTeachers = subject.MaxNumberOfTeachers

            });
            await _subjectRepository.SaveAsync();
        }

        /// <summary>
        /// Edit Subject By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subj"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> EditSubject(int id, SubjectModel subj)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if (subj.Credit != 0)
                {
                    subject.Credit = subj.Credit;
                }
                else
                {
                    subject.Credit = subject.Credit;
                }

                if (subj.Name != "string")
            { 

                    subject.Name = subj.Name;
                }

                else
                {
                    subject.Name = subject.Name;
                }

                if (subj.LowerBound != 0)
                {
                    subject.LowerBound = subj.LowerBound;
                }
                else
                {
                    subject.LowerBound = subject.LowerBound;
                }

                if (subj.MaxNumberOfStudents != 0)
                {
                    subject.MaxNumberOfStudents = subj.MaxNumberOfStudents;
                }
                else
                {
                    subject.MaxNumberOfStudents = subject.MaxNumberOfStudents;
                }

                if (subj.MaxNumberOfTeachers != 0)
                {
                    subject.MaxNumberOfTeachers = subj.MaxNumberOfTeachers;
                }
                else
                {
                    subject.MaxNumberOfTeachers = subject.MaxNumberOfTeachers;
                }

                _subjectRepository.Update(subject);
                await _subjectRepository.SaveAsync();
                 return Ok();

            }

        /// <summary>
        /// Delete Subject  By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var subject = await _dbcontext.Subjects.FindAsync(id);
            _dbcontext.Subjects.Remove(subject);
            await _dbcontext.SaveChangesAsync();

            return NoContent();
        }

    }

}
