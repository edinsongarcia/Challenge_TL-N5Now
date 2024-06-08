namespace ChallengeN5Now.Domain.Models
{
    public class PermissionType : Entity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
