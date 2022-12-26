using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using UniversityManagementSystem_Final.Model;
using UniversityManagementSystem_Final.Repositories;
using UniversityManagementSystem_Final.ViewModels;

namespace UniversityManagementSystem_Final.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {

        private readonly UniversityManagementSystemDbContext _dbcontext;

        private readonly IGenericRepository<Schedule> _scheduleRepository;
        /// <summary>
        /// IGeneric interface implementation
        /// </summary>
        public ScheduleController(IGenericRepository<Schedule> scheduleRepository,
            UniversityManagementSystemDbContext dbcontext)
        {
            _scheduleRepository = scheduleRepository;

            _dbcontext = dbcontext;

        }
        /// <summary>
        /// Get List Of Schedule
        /// </summary>
        /// <returns>list of shedule</returns>
        /// 

        [HttpGet]
        public async Task<IEnumerable<ScheduleModel>> GetAllSchedules()
        {
            var schedule = await _scheduleRepository.GetAllAsync();

            return schedule.Select(x => new ScheduleModel
            {
                Id=x.Id,
                StartTime = x.StartTime,
                EndTime = x.EndTime
            });
        }

        /// <summary>
        /// Get Schedule By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns schedule by its id</returns>


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Schedule), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ScheduleModel>> GetSchedule(int id)
        {
            var schedule = await _dbcontext.Schedules.FindAsync(id);

            if (schedule == null)
            {
                return StatusCode(500, $"Wrong Id number");
            }

            return Ok(schedule);
        }


        /// <summary>
        /// Insert Schedule
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns>returns ok when inserted</returns>
        /// 


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task AddScheedule(ScheduleModel schedule)
        {
            await _scheduleRepository.AddAsync(new Schedule
            {
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
            });
            await _scheduleRepository.SaveAsync();
        }



        /// <summary>
        ///  Edit Schedule By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sched"></param>
        /// <returns>ok when edited</returns>



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditSchedule(int id, ScheduleModel sched)
        {
            var shcedule = await _dbcontext.Schedules.FindAsync(id);
            
                shcedule.StartTime = sched.StartTime;
                shcedule.EndTime = sched.EndTime;
                _dbcontext.Schedules.Update(shcedule);
                await _dbcontext.SaveChangesAsync();
                return Ok();
        }

        /// <summary>
        /// Delete Schedule By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ok when deleted</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var schedule = await _dbcontext.Schedules.FindAsync(id);
            _dbcontext.Schedules.Remove(schedule);
            await _dbcontext.SaveChangesAsync();

            return NoContent();
        }

    }
}