using KafkaConsumer.Models;

namespace KafkaConsumer.Services
{
    public interface IConsumerService
    {
        ConsumerModel Consumer(CancellationToken cancellationToken);
    }
}
