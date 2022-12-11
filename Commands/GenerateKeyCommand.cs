using System;
using System.Security.Cryptography;
using McMaster.Extensions.CommandLineUtils;

namespace Infinite.Cipher.Commands
{
    [Command(name: "generate", Description = "Generate a new AES key.")]
    public class GenerateKeyCommand
    {
        private void OnExecute(CommandLineApplication app)
        {
            using var aesAlg = Aes.Create();
            Console.WriteLine($"The key is: {Convert.ToBase64String(aesAlg.Key)}");
        }
    }
}