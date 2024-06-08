using AutoMapper;
using ChallengeN5Now.Business.Permissions.Methods;
using ChallengeN5Now.Business.Permissions.Queries;
using ChallengeN5Now.Domain.Models;
using ChallengeN5Now.Services.Interfaces;
using MediatR;

namespace ChallengeN5Now.Business.Permissions
{
    public class PermissionHandler :
        IRequestHandler<GetAllPermissions, IEnumerable<Permission>>,
        IRequestHandler<CreatePermission, Permission>,
        IRequestHandler<UpdatePermission, Permission>

    {
        private readonly IMapper _mapper;
        private readonly IPermissionService _service;

        public PermissionHandler(IMapper mapper, IPermissionService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<IEnumerable<Permission>> Handle(GetAllPermissions request, CancellationToken cancellationToken)
        {
            return await _service.Get();
        }

        public async Task<Permission> Handle(CreatePermission request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Permission>(request);
            return await _service.Add(data);
        }

        public async Task<Permission> Handle(UpdatePermission request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<Permission>(request);
            return await _service.Update(data);
        }
    }

}
