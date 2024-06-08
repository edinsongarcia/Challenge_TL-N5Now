using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ChallengeN5Now.Services.Services.KafkaMessages
{
    public enum OperationType
    {
        get,
        request,
        modify
    }
    public class OperationMessage
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        [JsonConverter(typeof(StringEnumConverter))]
        public OperationType OperationType { get; protected set; }

        public OperationMessage(OperationType operationType)
        {
            this.OperationType = operationType;
        }
    }
}
