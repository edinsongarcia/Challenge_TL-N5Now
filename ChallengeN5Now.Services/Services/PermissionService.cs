using ChallengeN5Now.Data.Interfaces;
using ChallengeN5Now.Domain.Models;
using ChallengeN5Now.Services.Interfaces;
using ChallengeN5Now.Services.Services.KafkaMessages;
using Serilog;

namespace ChallengeN5Now.Services.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKafka _kafka;
        private readonly IElasticsearchService _elasticSearchService;


        public PermissionService(IUnitOfWork unitOfWork, IElasticsearchService elasticsearchService, IKafka kafka)
        {
            _unitOfWork = unitOfWork;
            _kafka = kafka;
            _elasticSearchService = elasticsearchService;

        }

        public async Task<IEnumerable<Permission>> Get()
        {
            var data = await _unitOfWork.PermissionRepository.GetAll();
            await _kafka.Publish(new OperationMessage(OperationType.get));
            return data;
        }

        public async Task<Permission> Add(Permission request)
        {
            if (_unitOfWork.PermissionRepository.HasEmployeePermission(request))
            {
                var data = new Permission();
                ArgumentNullException.ThrowIfNull(data);
                Log.Warning("The Employee " + request.EmployeeId + " already has the permission " + request.PermissionTypeId + " assigned");
                return data;
            }
            else
            {
                var inserted = await _unitOfWork.PermissionRepository.Add(request);
                await _unitOfWork.Save();
                var data = await _unitOfWork.PermissionRepository.Get(p => p.Id == inserted.Id);
                ArgumentNullException.ThrowIfNull(data);
                await _elasticSearchService.IndexDocument(data, data.Id.ToString());
                await _kafka.Publish(new OperationMessage(OperationType.request));
                return data;
            }
        }

        public async Task<Permission> Update(Permission request)
        {
            if (_unitOfWork.PermissionRepository.HasEmployeePermission(request))
            {
                var data = new Permission();
                ArgumentNullException.ThrowIfNull(data);
                Log.Warning("The Employee " + request.EmployeeId + " already has the permission " + request.PermissionTypeId + " assigned");
                return data;
            }
            else
            {
                var dataRequest = await _unitOfWork.PermissionRepository.Get(p => p.Id == request.Id);
                ArgumentNullException.ThrowIfNull(dataRequest);
                dataRequest.Active = request.Active;
                var data = _unitOfWork.PermissionRepository.Update(dataRequest);
                await _unitOfWork.Save();
                await _elasticSearchService.IndexDocument(data, data.Id.ToString());
                await _kafka.Publish(new OperationMessage(OperationType.modify));
                return data;
            }

        }
    }

}
