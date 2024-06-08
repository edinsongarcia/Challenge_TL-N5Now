using ChallengeN5Now.Domain.Models;
using MediatR;

namespace ChallengeN5Now.Business.Employess.Queries
{
    public class GetEmployeeById(int id) : IRequest<Employee>
    {
        public int EmployeeId { get; private set; } = id;
    }
}
