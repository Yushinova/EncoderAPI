using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace EncoderAPI.Encryption
{
    public class MD5Encoder : IEncoder
    {
        public string AlgoritmName => "MD5Encoder";

        public string Encode(string data)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] result = md5.ComputeHash(Encoding.UTF8.GetBytes(data));
                md5.Clear();
                return BitConverter.ToString(result);                
            }
        }
    }
}
