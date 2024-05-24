using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Candidate
    {
        public int Id { get; set; }
        
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
