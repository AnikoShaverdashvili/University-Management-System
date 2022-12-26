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
    public class BalanceController : ControllerBase
    {
        private readonly UniversityManagementSystemDbContext _dbcontext;
        private readonly IGenericRepository<Balance> _balanceRepository;
        public BalanceController(IGenericRepository<Balance> balanceRepository,
           UniversityManagementSystemDbContext dbcontext)
        {
            _balanceRepository = balanceRepository;

            _dbcontext = dbcontext;

        }
        /// <summary>
        ///Get List Of Balances
        /// </summary>
        /// <returns>The List of Balances</returns>
        [HttpGet]
        public async Task<IEnumerable<BalanceModel>> GetAllBalances()
        {
            List<BalanceModel> balanceModel = new();
            var balances = await _balanceRepository.GetAllAsync(null);

            return balances.Select(x => new BalanceModel
            {
                Amount = x.Amount,
                Debth = x.Debth
            });
        }

        /// <summary>
        /// Get Balance By  Id
        /// </summary>
        /// <returns>One Balance model</returns>
        /// 
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Balance), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<BalanceModel>>> Get(int id)
        {
            return Ok(await _balanceRepository.GetByIdAsync(id));
        }
       /// <summary>
       /// Insert Balance
       /// </summary>
       /// <param name="balance"></param>
       /// <returns>returns ok when inserted</returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddBalance(BalanceModel balance)
        {
            await _balanceRepository.AddAsync(new Balance
            {
                Debth = balance.Debth,
                Amount = balance.Amount,
                SemesterId=balance.SemesterId,
                StudentId=balance.StudentId
            });
            await _balanceRepository.SaveAsync();
            return Ok();
        }

        /// <summary>
        /// Edit Balance By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bal"></param>
        /// <returns>ok when edited</returns>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditAddress(int id, BalanceModel b)
        {
            var balance = await _dbcontext.Balances.FindAsync(id);
            if (b.SemesterId != 0)
            {
                balance.SemesterId = b.SemesterId;
            }
            else
            {
                balance.SemesterId = balance.SemesterId;
            }
            if (b.StudentId != 0)
            {
                balance.StudentId = b.StudentId;
            }
            if (b.Amount != 0)
            {
                balance.Amount = b.Amount;
            }
            else
            {
                balance.Amount = balance.Amount;
            }
            if (b.Debth != 0)
            {
                balance.Debth = b.Amount;
            }
            else
            {
                balance.Debth = balance.Debth;
            }
            _dbcontext.Balances.Update(balance);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Delete Balance By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ok when deleted</returns>
        /// 

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBalance(int id)
        {
            var balance = await _dbcontext.Balances.FindAsync(id);
            _dbcontext.Balances.Remove(balance);
            await _dbcontext.SaveChangesAsync();
            return NoContent();
        }
    }
}
