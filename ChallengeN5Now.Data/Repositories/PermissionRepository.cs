using ChallengeN5Now.Data.Interfaces;
using ChallengeN5Now.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChallengeN5Now.Data.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(AppDbContext dbContext) : base(dbContext) { }

        public override async Task<IEnumerable<Permission>> GetAll()
        {
            return await _dbSet.Include(x => x.Employee).Include(x => x.PermissionType).ToListAsync();
        }

        public override async Task<Permission?> Get(Expression<Func<Permission, bool>> expression)
        {
            return await _dbSet.Include(x => x.Employee).Include(x => x.PermissionType).FirstOrDefaultAsync(expression);
        }

        public override Permission Update(Permission entity)
        {
            _context.Update(entity).Property(x => x.Id).IsModified = false;
            return entity;
        }
        public override bool HasEmployeePermission(Permission entity)
        {
            var hasEmployeePermission = _context.Permissions.Where(w=>w.EmployeeId == entity.EmployeeId && w.PermissionTypeId == entity.PermissionTypeId && w.Active == true).Any();
            
            return hasEmployeePermission;
        }
    }
}
