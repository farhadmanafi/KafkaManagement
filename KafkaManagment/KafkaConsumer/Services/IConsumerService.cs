using KafkaConsumer.Models;
using System.Threading;

namespace KafkaConsumer.Services
{
    public interface IConsumerService
    {
        ConsumerModel Consumer(CancellationToken cancellationToken = new CancellationToken());
    }
}
