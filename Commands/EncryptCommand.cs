﻿using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using Infinite.Cipher.libs.CryptHash.Net;
using McMaster.Extensions.CommandLineUtils;

namespace Infinite.Cipher.Commands
{
    [Command(name: "encrypt", Description = "Encrypt a file using AES-256-GCM.")]
    public class EncryptCommand
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
                var text = Encoding.UTF8.GetBytes(File.ReadAllText(FileName));
                var key = Convert.FromBase64String(Key);

                var aes = new AEAD_AES_256_GCM();
                var result = Convert.ToBase64String(aes.EncryptString(text, key));

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
