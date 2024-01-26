using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;

namespace AsyncComm
{
    internal class Program
    {
        static void Mainttt(string[] args)
        {
            var connectionFactory = new ConnectionFactory 
            { HostName = "localhost", Port=5672, 
              UserName= "guest", Password="guest"
            };
            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("queue3", false, false, false, null);
            var body = Encoding.UTF8.GetBytes("Hello");

            while (true)
            {
                channel.BasicPublish("", "queue3", null, body);
                Thread.Sleep(1000);
            }

            channel.BasicPublish("", "queue3", null, body);

            connection.Close();
        }
    }
}
