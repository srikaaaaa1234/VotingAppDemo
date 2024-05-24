using AutoMapper;
using Backend.Dtos.Candidate;
using Backend.Dtos.Vote;
using Backend.Dtos.Voter;
using Backend.Model;

namespace Backend
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Voter, GetVoterDto>();
            CreateMap<GetVoterDto, Voter>();
            CreateMap<AddVoterDto, Voter>();

            CreateMap<Candidate, GetCandidateDto>();
            CreateMap<GetCandidateDto, Candidate>();
            CreateMap<AddCandidateDto, Candidate>();

            CreateMap<Vote, GetVoteDto>();
            CreateMap<GetVoteDto, Vote>();
            CreateMap<AddVoteDto, Vote>();
        }

    }
}
