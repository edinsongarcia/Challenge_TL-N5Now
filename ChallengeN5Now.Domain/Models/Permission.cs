namespace ChallengeN5Now.Domain.Models
{
    public class Permission : Entity
    {
        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public int PermissionTypeId { get; set; }
        public virtual PermissionType? PermissionType { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
