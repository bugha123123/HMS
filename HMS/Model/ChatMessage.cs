using System;
using System.ComponentModel.DataAnnotations;

namespace HMS.Model
{
    public class ChatMessage
    {
        public int ChatMessageId { get; set; }

        [Required]
        public string Sender { get; set; } // Who sent the message

        [Required]
        public string Recipient { get; set; } // Who the message is for

        [Required(ErrorMessage = "Message is required.")]
        [StringLength(200, ErrorMessage = "Message cannot exceed 200 characters.")]
        public string Message { get; set; } // Content of the message

        public DateTime SentAt { get; set; }  // DateTime when the message was sent

        public Chat Chat { get; set; }

        public int ChatId { get; set; }
    }
}
