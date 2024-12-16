using Confluent.Kafka;

var kafkaBootstrapServer = "localhost:9092";

var producerconfig = new ProducerConfig
{
    BootstrapServers = kafkaBootstrapServer
};

IProducer<Null, string> _producer = new ProducerBuilder<Null, string>(producerconfig).Build();

Console.WriteLine("Enter the topic name: ");
var topic = Console.ReadLine();

string? message = string.Empty;

do
{
    Console.WriteLine("Enter a message to procude: ");
    message = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(message))
    {
        var kafkamessage = new Message<Null, string> { Value = message };

        await _producer.ProduceAsync(topic, kafkamessage);
    }
} while (!string.IsNullOrWhiteSpace(message));
