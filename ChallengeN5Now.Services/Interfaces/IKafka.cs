using ChallengeN5Now.Services.Services.KafkaMessages;

namespace ChallengeN5Now.Services.Interfaces
{
    public interface IKafka
    {
        Task Publish(OperationMessage operationMessage);
    }
}
