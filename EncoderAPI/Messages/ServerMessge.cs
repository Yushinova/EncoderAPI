namespace EncoderAPI.Messages
{
    public class ServerMessge
    {
        public string? Message { get; set; }
        public string? StartTime => System.Diagnostics.Process.GetCurrentProcess().StartTime.ToLongTimeString();
        public string? NowTime => DateTime.Now.ToLongTimeString();
    }
}
