namespace HMS.Model
{
    public class Chat
    {
        public int ChatId { get; set; }
        public UserType UserType { get; set; }
        public ChatStatus Status { get; set; }  
        public int AppointmentId { get; set; }

        public Appointment appointment   { get; set; }

        public List<ChatMessage>? ChatMessages { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool? DoctorJoined { get; set; }  
        public bool? DoctorLeft { get; set; }    
        public bool? PatientJoined { get; set; } 
        public bool? PatientLeft { get; set; }


    }
}
