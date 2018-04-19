using Common;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueConsumer
{
    class Consumer
    {

        static void Main(string[] args)
        {
            string connectionString = Convert.ToString(ConfigurationManager.AppSettings["ServiceBus.ConnectionString"]);
            QueueClient qClient = QueueClient.CreateFromConnectionString(connectionString);
            // Continuously process messages sent to the "TestQueue" 
            while (true)
            {
                BrokeredMessage message = qClient.Receive();
                if (message != null)
                {
                    try
                    {
                        QueueMessage msg = message.GetBody<QueueMessage>();
                        Console.WriteLine(
                            $"Received Email {msg.Value} from {msg.Name} at {msg.Time}"
                        );
                        //Console.WriteLine("MessageID: " + message.MessageId);
                        //Remove message from queue
                        message.Complete();
                        System.Threading.Thread.Sleep(1000);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        // Indicate a problem, unlock message in queue
                        message.Abandon();
                    }
                }
            }
        }
    }
}
