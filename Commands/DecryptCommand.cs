using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using McMaster.Extensions.CommandLineUtils;

namespace Infinite.Cipher.Commands
{
    [Command(name: "decrypt", Description = "Decrypt a file using AES.")]
    public class DecryptCommand
    {
        [Argument(0)]
        [Required]
        [FileExists]
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
                var text = Convert.FromBase64String(File.ReadAllText(FileName));
                var key = Convert.FromBase64String(Key);
                using var myAes = Aes.Create();
                myAes.Key = key;
                myAes.IV = key[8..12].Concat(key[4..8]).Concat(key[12..16]).Concat(key[0..4]).ToArray();
                
                // Decrypt the bytes to a string.
                var result = CipherTool.DecryptStringFromBytes_Aes(text, myAes.Key, myAes.IV);
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
                Console.WriteLine($"File could not be decrypted: {e.Message}");
            }
        }
    }
}
