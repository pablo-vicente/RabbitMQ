﻿using RabbitMQ.Client;
using System;
using System.Text;

namespace Send
{
    class Send
    {
        static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" }; 
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
                string message = "Helllo World";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "logs",routingKey: "",basicProperties: null,body: body);
                Console.WriteLine(" [X] Sent {0}",message);
            }
            Console.WriteLine(" Press [ENTER] to exit.");
            Console.ReadLine();
        }
    }
}