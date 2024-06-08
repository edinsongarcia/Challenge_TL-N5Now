using ChallengeN5Now.Data.Interfaces;
using ChallengeN5Now.Domain.Models;

namespace ChallengeN5Now.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
