using Backend.Dtos.Candidate;
using Backend.Dtos.Voter;
using Backend.Model;
using Backend.Services;
using Backend.Services.VoterServices;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoterController : Controller
    {
        private readonly IVoterService _voterService;
        public VoterController(IVoterService voterService)
        {
            this._voterService = voterService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetVoterDto>>>> Get()
        {
            return Ok(await _voterService.Get());
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<GetVoterDto>>>> Add(AddVoterDto data)
        {
            return Ok(await _voterService.Add(data));
        }
    }
}
