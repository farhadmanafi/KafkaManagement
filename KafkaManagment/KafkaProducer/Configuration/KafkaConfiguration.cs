﻿using Confluent.Kafka;

namespace KafkaProducer.Configuration
{
    public class KafkaConfiguration
    {
        public string ProducerBootstrapServers { get; set; }
        public string ConsumerBootstrapServers { get; set; }
        public string ProducerTopicName { get; set; }
        public string ConsumerTopicName { get; set; }
        public int MessageTimeoutMs { get; set; }
        public Acks Acks { get; set; }
        public string GroupId { get; set; }
        public bool EnableAutoOffsetStore { get; set; }
        public bool EnableAutoCommit { get; set; }
        public AutoOffsetReset AutoOffsetReset { get; set; }
        public string OffsetPath { get; set; }
    }
}
