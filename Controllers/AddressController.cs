using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem_Final.Model;
using UniversityManagementSystem_Final.Repositories;
using UniversityManagementSystem_Final.ViewModels;

namespace UniversityManagementSystem_Final.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly UniversityManagementSystemDbContext _dbcontext;

        private readonly IGenericRepository<Address> _addressRepository;
        public AddressController(IGenericRepository<Address> addressRepository, UniversityManagementSystemDbContext dbcontext)
        {
            _addressRepository = addressRepository;
            _dbcontext = dbcontext;
        }

        /// <summary>
        ///Get List Of Addresses
        /// </summary>
        /// <returns>The List of Addresses</returns>
        [HttpGet]
        public async Task<IEnumerable<AddressModel>> GetAllAddressAsync()
        {
            var addresses = await _addressRepository.GetAllAsync();

            var rViewModel = addresses.Select(x => new AddressModel
            {
                Address1 = x.Address1,
                Address2 = x.Address2
            });

            return rViewModel;

        }
        /// <summary>
        /// Get Address By Id
        /// </summary>
        /// <returns>One address model</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AddressModel>>> GetAddressId(int id)
        {
            return Ok(await _addressRepository.GetByIdAsync(id));
        }

        /// <summary>
        /// Insert Address 
        /// </summary>
        /// <param name="address"></param>
        /// <returns>returns ok when inserted</returns>
        /// 

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddAddress(AddressModel address)
        {
            await _addressRepository.AddAsync(new Address
            {
                Address1 = address.Address1,
                Address2 = address.Address2,

            });
            await _addressRepository.SaveAsync();
            return Ok();
        }


        /// <summary>
        /// Edit Address By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addr"></param>
        /// <returns>ok when edited</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditAddress(int id, AddressModel addr)
        {
            var address = await _dbcontext.Addresses.FindAsync(id);

            if (addr.Address1 != "string")
            {

                address.Address1 = addr.Address1;
            }

            else
            {
                address.Address1 = address.Address1;
            }
            if (addr.Address2 != "string")
            {
                address.Address2 = addr.Address2;
            }
            else
            {
                address.Address2 = address.Address2;
            }
            _dbcontext.Addresses.Update(address);
            await _dbcontext.SaveChangesAsync();
            return Ok();

        }

        /// <summary>
        /// Delete Address By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ok when deleted</returns>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _dbcontext.Addresses.FindAsync(id);
            _dbcontext.Addresses.Remove(address);
            await _dbcontext.SaveChangesAsync();
            return NoContent();
        }


    }

}

