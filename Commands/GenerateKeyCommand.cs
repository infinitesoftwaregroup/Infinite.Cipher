using System;
using Infinite.Cipher.libs.CryptHash.Net;
using McMaster.Extensions.CommandLineUtils;

namespace Infinite.Cipher.Commands
{
    [Command(name: "generate", Description = "Generate a new AES-256 key.")]
    public class GenerateKeyCommand
    {
        private void OnExecute(CommandLineApplication app)
        {
            var key = CommonMethods.Generate256BitKey();

            Console.WriteLine(Convert.ToBase64String(key));
        }
    }
}
