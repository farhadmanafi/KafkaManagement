using Confluent.Kafka;
using KafkaConsumer.Configuration;
using KafkaConsumer.Models;
using Newtonsoft.Json;

namespace KafkaConsumer.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly KafkaConfiguration _kafkaConfiguration;
        public ConsumerService(KafkaConfiguration kafkaConfiguration)
        {
            _kafkaConfiguration = kafkaConfiguration;
            var config = new ConsumerConfig
            {
                GroupId = _kafkaConfiguration.GroupId,
                BootstrapServers = _kafkaConfiguration.ConsumerBootstrapServers,
                EnableAutoOffsetStore = _kafkaConfiguration.EnableAutoOffsetStore,
                AutoOffsetReset = _kafkaConfiguration.AutoOffsetReset,
                EnableAutoCommit = _kafkaConfiguration.EnableAutoCommit
            };

            _consumer = new ConsumerBuilder<string, string>(config).Build();
        }

        public ConsumerModel Consumer(CancellationToken cancellationToken)
        {
            _consumer.Subscribe(_kafkaConfiguration.ConsumerTopicName);

            var consumeResult = _consumer.Consume(cancellationToken);

            var consumerModel = JsonConvert.DeserializeObject<ConsumerModel>(
                consumeResult.Message.Value);

            return consumerModel;
        }
    }
}
