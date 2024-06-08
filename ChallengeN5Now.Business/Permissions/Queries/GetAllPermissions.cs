using ChallengeN5Now.Domain.Models;
using MediatR;

namespace ChallengeN5Now.Business.Permissions.Queries
{
    public class GetAllPermissions : IRequest<IEnumerable<Permission>>
    {
    }
}
