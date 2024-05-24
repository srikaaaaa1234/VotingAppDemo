using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Voter
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }
    }
}
