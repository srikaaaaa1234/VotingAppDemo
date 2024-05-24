using AutoMapper;
using Backend.Data;
using Backend.Dtos.Candidate;
using Backend.Dtos.Voter;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.VoterServices
{
    public interface IVoterService
    {
        Task<ServiceResponse<List<GetVoterDto>>> Get();
        Task<ServiceResponse<GetVoterDto>> Add(AddVoterDto data);
    }

    public class VoterService: IVoterService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VoterService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetVoterDto>>> Get()
        {
            ServiceResponse<List<GetVoterDto>> result = new ServiceResponse<List<GetVoterDto>>();
            result.Data = _mapper.Map<List<GetVoterDto>>(await _context.Voters.ToListAsync());
            return result;
        }


        public async Task<ServiceResponse<GetVoterDto>> Add(AddVoterDto data)
        {
            ServiceResponse<GetVoterDto> result = new ServiceResponse<GetVoterDto>();
            var x = _context.Voters.Add(_mapper.Map<Voter>(data));
            await _context.SaveChangesAsync();
            result.Data = _mapper.Map<GetVoterDto>(_context.Voters.FirstOrDefault(y => y.Id == x.Entity.Id));
            return result;
        }
    }
}
