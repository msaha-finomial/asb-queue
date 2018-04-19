using Common;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QueueProducer
{

    class Producer
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = Convert.ToString(ConfigurationManager.AppSettings["ServiceBus.ConnectionString"]);
                QueueClient qClient = QueueClient.CreateFromConnectionString(connectionString);
                Random random = new Random();
                for (int i = 0; i < 5; i++)
                {
                    var msg = new QueueMessage { Value = random.Next(1, 100), Name = "Mainak", Time = DateTime.Now };
                    Console.WriteLine(
                        $"Queued Email {msg.Value} at {msg.Time}"
                    );
                    var brMsg = new BrokeredMessage(msg);
                    qClient.Send(brMsg);
                    System.Threading.Thread.Sleep(2500);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception {e.Message}");
            }
            Console.ReadLine();
        }
    }
}
