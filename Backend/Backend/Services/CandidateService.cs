using AutoMapper;
using Backend.Data;
using Backend.Dtos.Candidate;
using Backend.Dtos.Voter;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public interface ICandidateService
    {
        Task<ServiceResponse<List<GetCandidateDto>>> Get();
        Task<ServiceResponse<GetCandidateDto>> Add(AddCandidateDto data);
    }
    public class CandidateService: ICandidateService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CandidateService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCandidateDto>>> Get()
        {
            ServiceResponse<List<GetCandidateDto>> result = new ServiceResponse<List<GetCandidateDto>>();
            result.Data = _mapper.Map<List<GetCandidateDto>>(await _context.Candidates.ToListAsync());
            return result;
        }

        public async Task<ServiceResponse<GetCandidateDto>> Add(AddCandidateDto data)
        {
            ServiceResponse<GetCandidateDto> result = new ServiceResponse<GetCandidateDto>();
            var x = _context.Candidates.Add(_mapper.Map<Candidate>(data));
            await _context.SaveChangesAsync();
            result.Data = _mapper.Map<GetCandidateDto>(_context.Candidates.FirstOrDefault(y => y.Id == x.Entity.Id));
            return result;
        }
    }
}
