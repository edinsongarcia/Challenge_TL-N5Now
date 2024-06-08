namespace ChallengeN5Now.Domain.Models
{
    public class Employee : Entity
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
