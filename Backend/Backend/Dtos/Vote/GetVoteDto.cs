namespace Backend.Dtos.Vote
{
    public class GetVoteDto
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int VoterId { get; set; }
    }
}
