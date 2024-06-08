using AutoMapper;
using ChallengeN5Now.Business.Employess.Methods;
using ChallengeN5Now.Domain.Models;

namespace ChallengeN5Now.Business.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployee, Employee>();
            CreateMap<UpdateEmployee, Employee>();
        }
    }
}
