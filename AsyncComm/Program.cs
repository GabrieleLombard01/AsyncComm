using RabbitMQ.Client;

namespace AsyncComm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionFactory = new ConnectionFactory 
            { HostName = "localhost", Port=5672, 
              UserName= "guest", Password="guest"
            };
            var connection = connectionFactory.CreateConnection();

            connection.Close();
        }
    }
}
