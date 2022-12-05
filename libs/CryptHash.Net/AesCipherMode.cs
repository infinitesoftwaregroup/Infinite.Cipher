/*
 *      Alessandro Cagliostro, 2020
 *      
 *      https://github.com/alecgn
 */

using System.Security.Cryptography;

namespace Infinite.Cipher.libs.CryptHash.Net
{
    public enum AesCipherMode { CBC = CipherMode.CBC, ECB = CipherMode.ECB, OFB = CipherMode.OFB, CFB = CipherMode.CFB, CTS = CipherMode.CTS, GCM };
}