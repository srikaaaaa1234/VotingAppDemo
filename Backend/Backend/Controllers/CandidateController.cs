using Backend.Dtos.Candidate;
using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        public CandidateController(ICandidateService candidateService)
        {
            this._candidateService = candidateService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCandidateDto>>>> Get()
        {
            return Ok(await _candidateService.Get());
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<AddCandidateDto>>>> Add(AddCandidateDto data)
        {
            return Ok(await _candidateService.Add(data));
        }
    }
}
