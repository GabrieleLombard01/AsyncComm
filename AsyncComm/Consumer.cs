using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncComm
{
    internal class Consumer
    {
        static void Main(string[] args)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("queue3", false, false, false, null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += Consumer_Received;

            channel.Close();
            connection.Close();
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {

        }


    }
}
