using ChallengeN5Now.Data.Interfaces;
using ChallengeN5Now.Domain.Models;

namespace ChallengeN5Now.Data.Repositories
{
    public class PermissionTypeRepository : Repository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
