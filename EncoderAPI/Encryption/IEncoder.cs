namespace EncoderAPI.Encryption
{
    public interface IEncoder
    {
        string AlgoritmName { get; }
        string Encode(string data);
        
    }
}
