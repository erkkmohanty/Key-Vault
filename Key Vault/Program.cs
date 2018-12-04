using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System;

namespace Key_Vault
{
    class Program
    {
        static void Main(string[] args)
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            var secret = keyVaultClient.GetSecretAsync("https://keyvaultkk.vault.azure.net/secrets/TheSecret")
                .Result;
            Console.WriteLine("Secret is::" + secret.Value);
            Console.ReadLine();
        }
    }
}
