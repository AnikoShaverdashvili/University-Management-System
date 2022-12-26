using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem_Final.Model;
using UniversityManagementSystem_Final.Repositories;
using UniversityManagementSystem_Final.ViewModels;

namespace UniversityManagementSystem_Final.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly UniversityManagementSystemDbContext _dbcontext;
        private readonly IGenericRepository<Department> _departmentRepository;
        public DepartmentController (IGenericRepository<Department> departmentRepository,
           UniversityManagementSystemDbContext dbcontext)
        {
            _departmentRepository = departmentRepository;
            _dbcontext = dbcontext;
        }

        /// <summary>
        ///Get List Of Departments
        /// </summary>
        /// <returns>The List of Departments</returns>
        [HttpGet]
        public async Task<IEnumerable<DepartmentModel>> GetAllBalances()
        {
            List<DepartmentModel> departmentModel = new();
            var balances = await _departmentRepository.GetAllAsync(null);
            return balances.Select(x => new DepartmentModel
            {
                Name=x.Name,
                MaxNumberStudents = x.MaxNumberStudents,
                CuttentAmount=x.CuttentAmount
            }) ;
        }

        /// <summary>
        /// Get Department By  Id
        /// </summary>
        /// <returns>One Department Model</returns>
        /// 

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Department), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> Get(int id)
        {
            return Ok(await _departmentRepository.GetByIdAsync(id));
        }

        /// <summary>
        /// Insert Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns>ok when iserted</returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddBalance(DepartmentModel department)
        {
            await _departmentRepository.AddAsync(new Department
            {
                Name = department.Name,
                SemesterId= department.SemesterId,  
                Students=department.Students,
                Teachers=department.Teachers,
                MaxNumberStudents=department.MaxNumberStudents,
                CuttentAmount=department.CuttentAmount
            });
            await _departmentRepository.SaveAsync();
            return Ok();
        }

        /// <summary>
        /// Edit Department By Id
        /// </summary>
        /// <returns>ok when edited</returns>
        /// 

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditAddress(int id, DepartmentModel d)
        {
            var department = await _dbcontext.Departments.FindAsync(id);
            if (d.SemesterId != 0)
            {
                department.SemesterId = d.SemesterId;
            }
            else
            {
                department.SemesterId = department.SemesterId;
            }
            if (d.Name != "string")
            {
                department.Name = d.Name;
            }
            else
            {
                d.Name = d.Name;
            }
            if (d.MaxNumberStudents != 0)
            {
                department.MaxNumberStudents = d.MaxNumberStudents;
            }
            else
            {
                department.MaxNumberStudents = department.MaxNumberStudents;
            }
            if (d.MaxNumberStudents != 0)
            {
                department.CuttentAmount = d.CuttentAmount;
            }
            else
            {
                department.CuttentAmount = department.CuttentAmount;
            }
            _dbcontext.Departments.Update(department);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Delete Department By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ok when deleted</returns>
        

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBalance(int id)
        {
            var department = await _dbcontext.Departments.FindAsync(id);
            _dbcontext.Departments.Remove(department);
            await _dbcontext.SaveChangesAsync();
            return NoContent();
        }

    }
}
