using ChallengeN5Now.Domain.Models;
using MediatR;

namespace ChallengeN5Now.Business.Employess.Methods
{
    public class CreateEmployee : IRequest<Employee>
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
    }
}
