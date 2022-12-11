using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Security.Cryptography;
using McMaster.Extensions.CommandLineUtils;

namespace Infinite.Cipher.Commands
{
    [Command(name: "encrypt", Description = "Encrypt a file using AES.")]
    public class EncryptCommand
    {
        [Argument(0)] [Required] [FileExists] 
        public string FileName { get; set; }

        [Option("-k", Description = "Required. The encryption key.")]
        [Required]
        public string Key { get; set; }

        [Option("-c", Description = "Output to screen only.")]
        public bool ConsoleOnly { get; set; } = false;

        private void OnExecute(CommandLineApplication app)
        {
            try
            {
                var text = File.ReadAllText(FileName);
                var key = Convert.FromBase64String(Key);

                using var myAes = Aes.Create();
                myAes.Key = key;
                myAes.IV = new byte[16];

                // Encrypt the string to an array of bytes.
                var encrypted = CipherTool.EncryptStringToBytes_Aes(text, myAes.Key, myAes.IV);
                var result = Convert.ToBase64String(encrypted);

                if (ConsoleOnly)
                {
                    Console.WriteLine(result);
                }
                else
                {
                    File.WriteAllText(FileName, result);
                    Console.WriteLine($"Wrote {result.Length} bytes to {Path.GetFileName(FileName)}.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"File could not be encrypted: {e.Message}");
            }
        }
    }
}