Make QueueProducer & QueueConsumer your startup projects. And Run.

In case you get on error if the queue does not exist, you need to create a queue first.
How to use your own queue - 
* Create a queue in Azure Service Bus
* Add Shared Access Policy in the Queue with read and write access.
* Copy the Primary connection string from the created SAS Policy into the App.config of QueueConsumer and QueueProducer projects
