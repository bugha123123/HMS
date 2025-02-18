namespace HMS.Model
{
    public class ChatMessage
    {
        public int ChatMessageId { get; set; }
        public int ChatId { get; set; }
        public string Sender { get; set; }  // Sender (Doctor/Patient)
        public string Message { get; set; }  // Content of the message
        public DateTime SentAt { get; set; }  // DateTime when the message was sent

        public virtual Chat Chat { get; set; }
    }
}
