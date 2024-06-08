using ChallengeN5Now.Business.PermissionsTypes.Methods;
using ChallengeN5Now.Domain.Models;
using AutoMapper;

namespace ChallengeN5Now.Business.Mappers
{
    public class PermissionTypeProfile : Profile

    {
        public PermissionTypeProfile()
        {
            CreateMap<CreatePermissionType, PermissionType>();
            CreateMap<UpdatePermissionType, PermissionType>();
        }
    }
}
