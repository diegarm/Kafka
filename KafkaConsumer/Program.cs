using Confluent.Kafka;
using System;
using System.Text.Json;

namespace KafkaConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var consumerConfig = new ConsumerConfig
            {
                GroupId = $"db.{Guid.NewGuid():N}.group.id",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<string,string>(consumerConfig).Build())
            {
                consumer.Subscribe("db.dbo.Person");

                try
                {
                    while (true)
                    {
                        var evento = consumer.Consume();

                        var eventoJson = JsonSerializer.Serialize(evento.Message);

                        Mensagem msg = null;

                        if(evento.Message.Value != null)
                        {
                            msg = JsonSerializer.Deserialize<Mensagem>(evento.Message?.Value);
                        }

                        var chave = JsonSerializer.Deserialize<KeyIndentification>(evento.Key);
                        var offset = evento.TopicPartitionOffset;

                        if(msg == null)
                        {
                            Console.WriteLine($"Exclusão - Pessoa - {chave.payload.id}");
                        }
                        else
                        {
                            if(msg.payload?.after != null && msg.payload?.before == null)
                            {
                                Console.WriteLine($"Inclusão - Pessoa - {chave.payload.id}");
                            }
                            else
                            {
                                if(msg.payload?.after == null)
                                {

                                }
                                else
                                {

                                }
                            }
                        }

                    }


                }
                catch (Exception)
                {

                    throw;
                }


            }
        }
    }
}
