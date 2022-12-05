using System.IO;

namespace Infinite.Cipher
{
    public static class Helpers
    {
        public static byte[] ToBytes(this Stream input)
        {
            using var ms = new MemoryStream();
            input.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
