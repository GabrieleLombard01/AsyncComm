using RabbitMQ.Client;
using
RabbitMQ.Client.Events
;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var body = Encoding.UTF8.GetBytes("Hello");

            channel.BasicPublish("", "queue3", null, body);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_received;


            channel.BasicConsume("queue3", true, consumer);
            Console.ReadLine();

            channel.Close();
            connection.Close();
        }

        private static void Consumer_received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine(message);
        }
    }



}