using Confluent.Kafka;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace KafkaConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var consumerConfig = new ConsumerConfig
            {
                GroupId = $"bpi.{Guid.NewGuid():N}.group.id",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<string,string>(consumerConfig).Build())
            {
                while (true)
                {
                    ConsumerTopic(consumer, "bpi.credits.participant.events", "Participant");
                    ConsumerTopic(consumer, "bpi.credits.simulation.events", "Simulation");
                }
            }
            
        }

        private static void ConsumerTopic(IConsumer<string, string> consumer,string topic,string tipo)
        {
            consumer.Subscribe(topic);

            try
            {

                var evento = consumer.Consume();

                var eventoJson = JsonSerializer.Serialize(evento.Message);

                Mensagem msg = null;

                if (evento.Message.Value != null)
                {
                    msg = JsonSerializer.Deserialize<Mensagem>(evento.Message?.Value);
                }

                ConsoleFormat(msg, topic, tipo);
                var offset = evento.TopicPartitionOffset;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private static void ConsoleFormat(Mensagem msg, string topic, string tipo)
        {
            Console.WriteLine($"TOPIC: {topic}");
            Console.WriteLine($"TIPO: {tipo}");
            Console.WriteLine($"PAYLOAD: {JsonSerializer.Serialize(msg.payload)}");
            Console.WriteLine($"----------------------------------------------------");
        }
    }
}
