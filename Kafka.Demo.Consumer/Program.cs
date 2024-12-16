using Confluent.Kafka;

var kafkaBootstrapServer = "localhost:9092";

var consumerConfig = new ConsumerConfig
{
    BootstrapServers = kafkaBootstrapServer,
    GroupId = "InventoryConsumerGroup",
    AutoOffsetReset = AutoOffsetReset.Earliest,
};

IConsumer<Ignore, string> _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

Console.WriteLine("Enter the topic name: ");
var topic = Console.ReadLine();

_consumer.Subscribe(topic);

while (true)
{
    var consumeResult = _consumer.Consume();

    if (consumeResult.Message != null)
    {
        var message = consumeResult.Message.Value;

        Console.WriteLine("A new message is consumed: {0}", message);
    }
}