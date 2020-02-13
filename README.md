---
page_type: sample
languages:
- csharp
products:
- azure
- azure-event-hubs
description: "How to send basic messages to an event hub."
urlFragment: event-hubs-dotnet-ingest
---

# How to send basic messages to an event hub

## SDK Versions

In this sample, you will find the following folders:

* **SB3** - references ServiceBus SDK v3
* **EH5** - references EventHubs SDK v5

## Prerequisites

To complete this tutorial:

* [Visual Studio]

If you don't have an Azure subscription, create a [free account] before you begin.

### Create an Event Hub using the Azure portal

Step 1 : Create a new Event Hub Namespace to use for this tutorial.

*  Go to the [Azure Portal] and log in using your Azure account.
*  Select **New** > **Event Hubs** > **Create**.
*  Enter a name for your Event Hub Namespace.
*  Set `Pricing tier` to **Standard**.
*  Select your Subscription.
*  For `Resource group`, create a new one and give it a unique name.
*  Select the `Location` to use for your Event Hub Namespace.
*  Click **Create** to create your Event Hub Namespace.

Step 2: Create a new Event Hub to use for this tutorial.

*  Go to the Event Hub Namespace just created.
*  Select **Entities** > **Event Hubs** > **Event Hub**.
*  Enter a name for your Event Hub.
*  Click **Create** to create your Event Hub.

Step 3 : Copy and save connection sring.

 * After your Event Hub is created. Click on it to open it. Select **Settings** > **Shared access policies** > **RootManageSharedAccessKey** > **Connection string–primary key / Connection string–secondary key**, Select a connection string and copy the **connection string** to the clipboard, then paste it into text editor for later use.

### Set credentials in environment variables 

Linux
``` bash
export AZURE_EVENTHUB_NAME="<YourEventHubName>"
export AZURE_EVENTHUB_NAMESPACE_CONNECTIONSTRING="<YourConnectionString>"
```

Windows
``` cmd
setx AZURE_EVENTHUB_NAME "<YourEventHubName>"
setx AZURE_EVENTHUB_NAMESPACE_CONNECTIONSTRING "<YourConnectionString>"
```

## Run the application

First, clone the repository on your machine:

``` bash
git clone https://github.com/Azure-Samples/event-hubs-dotnet-ingest.git
```

Then, switch to the appropriate folder:
``` cmd
cd SB3
```
or
``` cmd
cd EH5
```

Finally, open `EventHubSampleData.sln` with Visual Studio, and run the application.

## This sample shows how to do the following operations of Event Hub

> * Create Event Hub Namespace and Event Hub using the Azure portal
> * send messages to an event hub

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct]. For more information see the [Code of Conduct FAQ] or contact [opencode@microsoft.com] with any additional questions or comments.

<!-- LINKS -->
[Visual Studio]:https://visualstudio.microsoft.com/zh-hans/downloads/
[free account]: https://azure.microsoft.com/free/?WT.mc_id=A261C142F
[Azure Portal]: https://portal.azure.com
[Microsoft Open Source Code of Conduct]: https://opensource.microsoft.com/codeofconduct/
[Code of Conduct FAQ]: https://opensource.microsoft.com/codeofconduct/faq/
[opencode@microsoft.com]: mailto:opencode@microsoft.com