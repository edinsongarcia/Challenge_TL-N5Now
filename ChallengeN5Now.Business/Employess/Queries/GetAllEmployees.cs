using ChallengeN5Now.Domain.Models;
using MediatR;

namespace ChallengeN5Now.Business.Employess.Queries
{
    public class GetAllEmployees : IRequest<IEnumerable<Employee>>
    {
    }

}
