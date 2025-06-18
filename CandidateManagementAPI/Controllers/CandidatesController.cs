using CandidateManagementAPI.DTOs;
using CandidateManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _service;

        public CandidatesController(ICandidateService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate([FromBody] CandidateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email)) return BadRequest("Email is required.");

            await _service.AddOrUpdateCandidateAsync(dto);
            return Ok("Candidate saved.");
        }
    }
}

