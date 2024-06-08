using ChallengeN5Now.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5Now.Business.Employess.Methods
{
    public class UpdateEmployee : IRequest<Employee>
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
    }
}
