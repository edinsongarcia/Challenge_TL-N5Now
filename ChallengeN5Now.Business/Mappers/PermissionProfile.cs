using AutoMapper;
using ChallengeN5Now.Business.Permissions.Methods;
using ChallengeN5Now.Domain.Models;

namespace ChallengeN5Now.Business.Mappers
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<CreatePermission, Permission>();
            CreateMap<UpdatePermission, Permission>();
        }
    }
}
