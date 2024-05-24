using AutoMapper;
using Backend.Data;
using Backend.Dtos.Vote;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public interface IVoteService
    {
        Task<ServiceResponse<List<GetVoteDto>>> Get();
        Task<ServiceResponse<GetVoteDto>> Add(AddVoteDto data);
    }
    public class VoteService: IVoteService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VoteService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetVoteDto>>> Get()
        {
            ServiceResponse<List<GetVoteDto>> result = new ServiceResponse<List<GetVoteDto>>();
            result.Data = _mapper.Map<List<GetVoteDto>>(await _context.Votes.ToListAsync());
            return result;
        }


        public async Task<ServiceResponse<GetVoteDto>> Add(AddVoteDto data)
        {
            ServiceResponse<GetVoteDto> result = new ServiceResponse<GetVoteDto>();

            if (_context.Voters.FirstOrDefault(x =>x.Id == data.VoterId) == null)
            {
                result.Status = false;
                result.Message = "Voter Not Found";
                return result;
            }

            if (_context.Candidates.FirstOrDefault(x => x.Id == data.CandidateId) == null)
            {
                result.Status = false;
                result.Message = "Candidate Not Found";
                return result;
            }

            var x = _context.Votes.Add(_mapper.Map<Vote>(data));
            await _context.SaveChangesAsync();
            result.Data = _mapper.Map<GetVoteDto>(_context.Votes.FirstOrDefault(y => y.Id == x.Entity.Id));
            return result;
        }
    }
}
