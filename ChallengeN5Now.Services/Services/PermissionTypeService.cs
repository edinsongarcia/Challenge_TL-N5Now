using ChallengeN5Now.Data.Interfaces;
using ChallengeN5Now.Domain.Models;
using ChallengeN5Now.Services.Interfaces;

namespace ChallengeN5Now.Services.Services
{
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionTypeService(IUnitOfWork unitOfWork, IElasticsearchService elasticsearchService, IKafka kafka)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PermissionType>> Get()
        {
            var data = await _unitOfWork.PermissionTypeRepository.GetAll();
            return data;
        }

        public async Task<PermissionType?> Get(long id)
        {
            var data = await _unitOfWork.PermissionTypeRepository.Get(x => x.Id == id);
            return data;
        }

        public async Task<PermissionType> Add(PermissionType request)
        {
            var data = await _unitOfWork.PermissionTypeRepository.Add(request);
            await _unitOfWork.Save();
            return data;
        }

        public async Task<PermissionType> Update(PermissionType request)
        {
            var data = _unitOfWork.PermissionTypeRepository.Update(request);
            await _unitOfWork.Save();
            return data;
        }
    }
}
