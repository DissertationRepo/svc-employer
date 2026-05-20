using AutoMapper;
using EmployerService.Api.Models;
using EmployerService.Application.Abstract_Services;
using EmployerService.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployerService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _employerService;
        private readonly IMapper _mapper;

        public EmployerController(IEmployerService employerService, IMapper mapper)
        {
            _employerService = employerService ?? throw new ArgumentNullException(nameof(employerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("create")]
        //[Authorize]
        public async Task<IActionResult> CreateEmployer([FromBody] NewEmployer newEmployer)
        {
            var employerCommand = _mapper.Map<EmployerModel>(newEmployer);
            await _employerService.CreateEmployerAsync(employerCommand);
            return Ok();
        }

        [HttpGet("employer/{id}")]
        //[Authorize]
        public async Task<IActionResult> GetEmployerById(string id)
        {
            if (!Guid.TryParse(id, out var guid))
            {
                return BadRequest("Invalid employer ID format. Please provide a valid GUID.");
            }

            var employer = await _employerService.GetEmployerByIdAsync(guid);
            if (employer is null)
            {
                return NotFound();
            }

            var response = _mapper.Map<EmployerResponse>(employer);
            return Ok(response);
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> SearchByCompanyName([FromQuery] string companyName)
        {
            if (string.IsNullOrWhiteSpace(companyName))
            {
                return BadRequest("Please provide a company name to search for.");
            }

            var employers = await _employerService.GetEmployersByCompanyNameAsync(companyName);
            var results = employers.Where(e => e is not null)
                                   .Select(e => _mapper.Map<EmployerResponse>(e!))
                                   .ToList();

            if (!results.Any())
            {
                return NotFound();
            }

            return Ok(results);
        }

        [HttpGet("by-user/{userId}")]
        //[Authorize]
        public async Task<IActionResult> GetEmployerByUserId(string userId)
        {
            if (!Guid.TryParse(userId, out var guid))
            {
                return BadRequest("Invalid user ID format. Please provide a valid GUID.");
            }

            var employer = await _employerService.GetEmployerByUserIdAsync(guid);
            if (employer is null)
            {
                return NotFound();
            }

            var response = _mapper.Map<EmployerResponse>(employer);
            return Ok(response);
        }

        [HttpPut("update")]
        //[Authorize]
        public async Task<IActionResult> UpdateEmployer([FromBody] UpdateEmployer updateEmployer)
        {
            var updateModel = _mapper.Map<UpdateEmployerModel>(updateEmployer);
            var updated = await _employerService.UpdateEmployerAsync(updateModel);
            if (!updated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteEmployer(string id)
        {
            if (!Guid.TryParse(id, out _))
            {
                return BadRequest("Invalid employer ID format. Please provide a valid GUID.");
            }

            var deleted = await _employerService.DeleteEmployerAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
