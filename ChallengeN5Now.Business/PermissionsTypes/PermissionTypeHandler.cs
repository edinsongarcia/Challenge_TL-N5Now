using AutoMapper;
using ChallengeN5Now.Business.PermissionsTypes.Methods;
using ChallengeN5Now.Business.PermissionsTypes.Queries;
using ChallengeN5Now.Domain.Models;
using ChallengeN5Now.Services.Interfaces;
using MediatR;

namespace ChallengeN5Now.Business.PermissionsTypes
{
    public class PermissionTypeHandler :
        IRequestHandler<GetAllPermissionTypes, IEnumerable<PermissionType>>,
        IRequestHandler<CreatePermissionType, PermissionType>,
        IRequestHandler<UpdatePermissionType, PermissionType>

    {
        private readonly IMapper _mapper;
        private readonly IPermissionTypeService _service;

        public PermissionTypeHandler(IMapper mapper, IPermissionTypeService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<IEnumerable<PermissionType>> Handle(GetAllPermissionTypes request, CancellationToken cancellationToken)
        {
            return await _service.Get();
        }

        public async Task<PermissionType> Handle(CreatePermissionType request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<PermissionType>(request);
            return await _service.Add(data);
        }

        public async Task<PermissionType> Handle(UpdatePermissionType request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<PermissionType>(request);
            return await _service.Update(data);
        }
    }

}
