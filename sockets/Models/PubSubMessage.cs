namespace sockets.Models
{
    public class PubSubMessage
    {
        public string Message { get; set; } = string.Empty;
        public string ToId { get; set; } = string.Empty;
    }
}
