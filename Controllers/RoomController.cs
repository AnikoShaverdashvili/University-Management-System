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
    public class RoomController : ControllerBase
    {

        private readonly UniversityManagementSystemDbContext _dbcontext;

        private readonly IGenericRepository<Room> _roomRepository;
       
        public RoomController(IGenericRepository<Room> roomRepository,
            UniversityManagementSystemDbContext dbcontext)
        {
            _roomRepository = roomRepository;

            _dbcontext = dbcontext;

        }
        /// <summary>
        /// Get List Of Rooms
        /// </summary>
        /// <returns>list of room</returns>

        [HttpGet]
        public async Task<IEnumerable<RoomModel>> GetAllRooms()
        {

            // Expression<Func<Department, object>> includes = exp => exp.Student;

            var rooms = await _roomRepository.GetAllAsync(null);

            return rooms.Select(x => new RoomModel
            {
                Description = x.Description,
                IsFree = x.IsFree,

                MaxNumberOfStudents = x.MaxNumberOfStudents,

            });
        }

        /// <summary>
        /// Get Room By Id
        /// </summary>
        /// <returns>ok when get</returns>
       
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RoomModel>> GetRoom(int id)
        {
            var room = await _dbcontext.Rooms.FindAsync(id);
            return Ok(room);
        }

        /// <summary>
        /// Insert Room
        /// </summary>
        /// <returns>ok when inserted</returns>
        

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task AddRoom(RoomModel room)
        {
            await _roomRepository.AddAsync(new Room
            {
                Description = room.Description,
                IsFree = room.IsFree,
                MaxNumberOfStudents = room.MaxNumberOfStudents,

            });
            await _roomRepository.SaveAsync();
        }

        /// <summary>
        /// Edit Room By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="r"></param>
        /// <returns>ok when edited</returns>
        /// 

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditRoom(int id, RoomModel r)
        {
            var room = await _dbcontext.Rooms.FindAsync(id);
          
                if (r.Description != "string")
                {
                    room.Description = r.Description;
                }
                else
                {
                    room.Description = room.Description;
                }

                if (r.MaxNumberOfStudents != 0)
                {
                     room.MaxNumberOfStudents = r.MaxNumberOfStudents;
                }
                else
                {
                    room.MaxNumberOfStudents = room.MaxNumberOfStudents;
                }
                if (r.IsFree != false)
                {
                    room.IsFree = room.IsFree;
                }
                else
                {
                    room.IsFree = room.IsFree;
                }
                _dbcontext.Rooms.Update(room);
                await _dbcontext.SaveChangesAsync();
                return Ok();

            }

            /// <summary>
            /// Delete Room By Id
            /// </summary>
            /// <returns>Status ok if it was deleted</returns>

            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<IActionResult> DeleteRoom(int id)
            {
                var room = await _dbcontext.Rooms.FindAsync(id);
                if (room == null)
                {
                    return StatusCode(500, $"Wrong Id number");
                }

                _dbcontext.Rooms.Remove(room);
                await _dbcontext.SaveChangesAsync();

                return NoContent();
            }



        }

    }
