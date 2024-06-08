using ChallengeN5Now.Data.Interfaces;

namespace ChallengeN5Now.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPermissionRepository _permission;
        private readonly IPermissionTypeRepository _permissionType;

        public UnitOfWork(AppDbContext context,
            IEmployeeRepository employeeRepository,
            IPermissionRepository permissionRepository,
            IPermissionTypeRepository permissionTypeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
            _permission = permissionRepository;
            _permissionType = permissionTypeRepository;
        }

        public IEmployeeRepository EmployeeRepository => _employeeRepository;
        public IPermissionRepository PermissionRepository => _permission;
        public IPermissionTypeRepository PermissionTypeRepository => _permissionType;

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
