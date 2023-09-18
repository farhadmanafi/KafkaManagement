using Confluent.Kafka;

namespace KafkaProducer.Services
{
    public interface IProducerService<TKey, TMessage>
    {
        Task<DeliveryResult<TKey, TMessage>> Producer(TKey key, TMessage message, string topicName, int partitionNumber, CancellationToken cancellationToken = default);
    }
}
