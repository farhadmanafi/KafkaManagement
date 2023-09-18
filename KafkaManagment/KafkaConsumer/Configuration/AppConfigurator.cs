namespace KafkaConsumer.Configuration
{
    public static class AppConfigurator
    {
        public static void ConfigKafka(IServiceCollection serviceCollection, HostBuilderContext context)
        {
            var config = context.Configuration.GetSection("KafkaConfiguration").Get<KafkaConfiguration>();

            serviceCollection.AddSingleton(config);
        }
    }
}
