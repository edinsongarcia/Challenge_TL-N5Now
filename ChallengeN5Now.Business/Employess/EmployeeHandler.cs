using AutoMapper;
using ChallengeN5Now.Business.Employess.Methods;
using ChallengeN5Now.Business.Employess.Queries;
using ChallengeN5Now.Domain.Models;
using ChallengeN5Now.Services.Interfaces;
using MediatR;

namespace ChallengeN5Now.Business.Employess
{
    public class EmployeeHandler :
        IRequestHandler<GetAllEmployees, IEnumerable<Employee>>,
        IRequestHandler<GetEmployeeById, Employee?>,
        IRequestHandler<CreateEmployee, Employee>,
        IRequestHandler<UpdateEmployee, Employee>

    {
        private readonly IMapper _mapper;
        private readonly IEmployeesService _service;

        public EmployeeHandler(IMapper mapper, IEmployeesService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<IEnumerable<Employee>> Handle(GetAllEmployees request, CancellationToken cancellationToken)
        {
            return await _service.Get();
        }

        public async Task<Employee?> Handle(GetEmployeeById request, CancellationToken cancellationToken)
        {
            return await _service.Get(request.EmployeeId);
        }

        public async Task<Employee> Handle(CreateEmployee request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Employee>(request);
            return await _service.Update(data);
        }

        public async Task<Employee> Handle(UpdateEmployee request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Employee>(request);
            return await _service.Update(data);
        }
    }
}
