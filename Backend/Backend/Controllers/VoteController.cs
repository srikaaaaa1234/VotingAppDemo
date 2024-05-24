using Backend.Dtos.Candidate;
using Backend.Dtos.Vote;
using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoteController : Controller
    {
        private readonly IVoteService _voteService;
        public VoteController(IVoteService voteService)
        {
            this._voteService = voteService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCandidateDto>>>> Get()
        {
            return Ok(await _voteService.Get());
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<AddVoteDto>>>> Add(AddVoteDto data)
        {
            return Ok(await _voteService.Add(data));
        }
    }
}
