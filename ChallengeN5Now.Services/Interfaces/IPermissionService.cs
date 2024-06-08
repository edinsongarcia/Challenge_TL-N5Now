using ChallengeN5Now.Domain.Models;

namespace ChallengeN5Now.Services.Interfaces
{
    public interface IPermissionService
    {
        public Task<IEnumerable<Permission>> Get();
        public Task<Permission> Add(Permission request);
        public Task<Permission> Update(Permission request);
    }
}
