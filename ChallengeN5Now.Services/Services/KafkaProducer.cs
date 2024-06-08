using ChallengeN5Now.Services.Interfaces;
using ChallengeN5Now.Services.Services.KafkaMessages;
using Confluent.Kafka;
using Newtonsoft.Json;
using Serilog;

namespace ChallengeN5Now.Services.Services
{
    public class KafkaProducer : IKafka
    {
        public readonly ProducerConfig config;

        public KafkaProducer(string? url)
        {
            ArgumentNullException.ThrowIfNull(url);
            config = new ProducerConfig
            {
                BootstrapServers = url
            };
        }

        public async Task Publish(OperationMessage operationMessage)
        {
            try
            {
                using var producer = new ProducerBuilder<string, string>(config).Build();

                var topic = "permissionoperation";

                var message = new Message<string, string>
                {
                    Key = operationMessage.Id.ToString(),
                    Value = JsonConvert.SerializeObject(operationMessage),
                };

                var response = await producer.ProduceAsync(topic, message);

                if (response.Status == PersistenceStatus.NotPersisted)
                {
                    throw new ArgumentException("Message not persisted");
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error to publish message:{@operationMessage}, ex:{@ex}", operationMessage, ex);
            }
        }
    }
}
