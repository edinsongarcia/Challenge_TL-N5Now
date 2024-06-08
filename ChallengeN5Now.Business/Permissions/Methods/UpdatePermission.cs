using ChallengeN5Now.Domain.Models;
using MediatR;

namespace ChallengeN5Now.Business.Permissions.Methods
{
    public class UpdatePermission : IRequest<Permission>
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PermissionTypeId { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
