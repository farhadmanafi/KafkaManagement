using KafkaConsumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace KafkaConsumer.Controllers
{
    public class KafkaConsumerController : Controller
    {
        private readonly IConsumerService _consumerService;

        public KafkaConsumerController(IConsumerService consumerService)
        {
            _consumerService = consumerService;
        }

        public async Task Consumer()
        {
            _consumerService.Consumer();
        }
    }
}
