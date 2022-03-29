namespace KafkaConsumer
{

    public class Mensagem
    {
        public Schema schema { get; set; }
        public string payload { get; set; }
    }

    public class Schema
    {
        public string type { get; set; }
        public bool optional { get; set; }
    }





}