namespace HMS.Model
{
    public class Chat
    {
        public int ChatId { get; set; }
        public UserType UserType { get; set; }
        public ChatStatus Status { get; set; }  
        public int UserId { get; set; }  
        public string Message { get; set; } 
        public DateTime CreatedAt { get; set; }

  
    }
}
