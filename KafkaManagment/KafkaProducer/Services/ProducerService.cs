using Confluent.Kafka;
using KafkaProducer.Configuration;

namespace KafkaProducer.Services
{
    public class ProducerService<TKey, TMessage> : IProducerService<TKey, TMessage>
    {
        private readonly KafkaConfiguration _configuration;
        private readonly IProducer<TKey, TMessage> _producer;
        public ProducerService(KafkaConfiguration configuration)
        {
            _configuration = configuration;
            var config = new ProducerConfig()
            {
                BootstrapServers = configuration.ProducerBootstrapServers,
                MessageTimeoutMs = configuration.MessageTimeoutMs,
                Acks = Acks.All
            };

            _producer = new ProducerBuilder<TKey, TMessage>(config).Build();

        }
        public async Task<DeliveryResult<TKey, TMessage>> Producer(TKey key, TMessage message, string topicName, int partitionNumber, CancellationToken cancellationToken = default)
        {
            return await _producer.ProduceAsync(new TopicPartition(topicName, new Partition(partitionNumber)), new Message<TKey, TMessage>
            {
                Value = message,
                Key = key
            }, cancellationToken);
        }
    }
}
