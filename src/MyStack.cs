using Pulumi;
using Pulumi.Azure.Core;
using Pulumi.Azure.Storage;

class MyStack : Stack
{
    public MyStack()
    {
        // Create an Azure Resource Group
        var resourceGroup = new ResourceGroup("rgPulumi");

for (int i = 0; i < 5; i++)
{
     // Create an Azure Storage Account
        var storageAccount = new Account("saPulumi" + i.ToString(), new AccountArgs
        {
            ResourceGroupName = resourceGroup.Name,
            AccountReplicationType = "LRS",
            AccountTier = "Standard"
        });

        // Export the connection string for the storage account
        this.ConnectionString = storageAccount.PrimaryConnectionString;
}
       
    }

    [Output]
    public Output<string> ConnectionString { get; set; }
}
