
using System.ComponentModel;

namespace EncoderAPI.Encryption
{
    public class BCryptEncoder : IEncoder
    {
        public string AlgoritmName => "BCryptEncoder";

        public string Encode(string data)
        {
            string cryptdata = BCrypt.Net.BCrypt.HashPassword(data);
            //Console.WriteLine(BCrypt.Net.BCrypt.Verify(data,cryptdata));//сравнение исходных данных и полученных
            return cryptdata;
 
        }
    }
}
