using ChallengeN5Now.Domain.Models;
using MediatR;

namespace ChallengeN5Now.Business.Permissions.Methods
{
    public class CreatePermission : IRequest<Permission>
    {
        public int EmployeeId { get; set; }
        public int PermissionTypeId { get; set; }
        public bool Active { get; set; } = true;
    }
}
