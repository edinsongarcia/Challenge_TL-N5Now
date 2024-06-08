using ChallengeN5Now.Domain.Models;
using MediatR;

namespace ChallengeN5Now.Business.PermissionsTypes.Queries
{
    public class GetAllPermissionTypes : IRequest<IEnumerable<PermissionType>>
    {
    }
}
