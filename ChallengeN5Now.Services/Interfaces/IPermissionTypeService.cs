using ChallengeN5Now.Domain.Models;

namespace ChallengeN5Now.Services.Interfaces
{
    public interface IPermissionTypeService
    {
        public Task<IEnumerable<PermissionType>> Get();

        public Task<PermissionType?> Get(long id);

        public Task<PermissionType> Add(PermissionType request);

        public Task<PermissionType> Update(PermissionType request);
    }
}
