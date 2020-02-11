using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SendSampleData
{
    class Program
    {
        const string eventHubName = "test-hub";
        // Copy the connection string ("Connection string-primary key") from your Event Hub namespace.
        const string connectionString = @"<YourConnectionString>";

        static async Task Main(string[] args)
        {
            await EventHubIngestion();
        }

        static async Task EventHubIngestion()
        {
            await using (var producer = new EventHubProducerClient(connectionString, eventHubName))
            {
                string[] partitionIds = await producer.GetPartitionIdsAsync();

                EventDataBatch eventBatch = await producer.CreateBatchAsync();

                int counter = 0;
                for (int i = 0; i < 100; i++)
                {
                    int recordsPerMessage = 3;
                    try
                    {
                        List<string> records = Enumerable
                            .Range(0, recordsPerMessage)
                            .Select(recordNumber => $"{{\"timeStamp\": \"{DateTime.UtcNow.AddSeconds(100 * counter)}\", \"name\": \"{$"name {counter}"}\", \"metric\": {counter + recordNumber}, \"source\": \"EventHubMessage\"}}")
                            .ToList();
                        string recordString = string.Join(Environment.NewLine, records);

                        EventData eventData = new EventData(Encoding.UTF8.GetBytes(recordString));
                        eventBatch.TryAdd(eventData);
                        Console.WriteLine($"sending message {counter}");
                        // Optional "dynamic routing" properties for the database, table, and mapping you created. 
                        // eventData.Properties.Add("Table", "TestTable");
                        // eventData.Properties.Add("IngestionMappingReference", "TestMapping");
                        // eventData.Properties.Add("Format", "json");
                        await producer.SendAsync(eventBatch);
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0} > Exception: {1}", DateTime.Now, exception.Message);
                        Console.ResetColor();
                    }

                    counter += recordsPerMessage;

                    Thread.Sleep(10000);
                }
            } 
        }
    }
}
