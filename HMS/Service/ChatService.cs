using HMS.DB;
using HMS.Interface;
using HMS.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HMS.Service
{
    public class ChatService : IChatService
    {
        private readonly IAuthService _authservice;
        private readonly AppDbContextion _db;
        private readonly IAdminService _adminservice;


        public ChatService(IAuthService authservice, AppDbContextion db, IAdminService adminservice)
        {
            _authservice = authservice;
            _db = db;
            _adminservice = adminservice;
        }

        public async Task<int> CreateChat(UserType userType, int appId)
        {
            var foundAppointment = await _adminservice.GetAppointmentById(appId);

            if (foundAppointment is null)
                return 0; // If the appointment is not found, return 0

            var existingChat = await IsChatAlreadyCreated(appId);

            if (existingChat != null)
            {
                if (userType == UserType.Patient)
                {
                existingChat.PatientJoined = true;
                await _db.SaveChangesAsync();
                }
      
                return existingChat.ChatId;

                
            }

            // If no existing chat is found, create a new one
            var chatToCreate = new Chat()  
            {
                CreatedAt = DateTime.Now,
                Status = ChatStatus.Pending,
                UserType = userType,
                AppointmentId = appId,
                

            };

            if (userType == UserType.Doctor)
            {
                chatToCreate.DoctorJoined = true;
            }
          
          

                await _db.Chats.AddAsync(chatToCreate);
            await _db.SaveChangesAsync();

            // TODO: Add notifications & email logic here

            return chatToCreate.ChatId; // Return the newly created chat's ID
        }

      

        public async Task<Chat> GetChatById(int ChatId)
        {
            return await _db.Chats.Include(x => x.appointment).ThenInclude(x => x.Patient).Include(x => x.appointment.Doctor).FirstOrDefaultAsync(x => x.ChatId == ChatId);
        }

        public async Task<List<ChatMessage>> GetSameChatMessages(int chatId)
        {
            return await _db.ChatMessages
                .Where(m => m.ChatId == chatId)
                .OrderBy(m => m.SentAt) 
                .ToListAsync();
        }


        public async Task<Chat> IsChatAlreadyCreated(int appId)
        {
            // Retrieve the existing chat based on AppointmentId and that is not closed
            var existingChat = await _db.Chats
                .FirstOrDefaultAsync(c => c.AppointmentId == appId && c.Status != ChatStatus.Closed);

            return existingChat;  // Return the Chat object if found, or null if not found
        }

        public async Task<bool> IsChatOpen(int AppointmentId)
        {
            var result = await _db.Chats
                                   .FirstOrDefaultAsync(x => x.AppointmentId == AppointmentId && x.Status != ChatStatus.Closed);

           
            return result != null;
        }

        public async Task<int> SendMessage(int ChatId, string Sender, string messageInput, int AppointmentId)
        {


            if (ChatId <= 0 || string.IsNullOrWhiteSpace(Sender) || string.IsNullOrWhiteSpace(messageInput) || AppointmentId < 0)
            {
                return 0;
            }

            var FoundChat = await GetChatById(ChatId);

            var FoundAppointment = await _adminservice.GetAppointmentById(AppointmentId);

            if (FoundChat is null || FoundAppointment is null)
                return 0 ;


            var MessageToSend = new ChatMessage()
            {
                ChatId = FoundChat.ChatId,
                Chat = FoundChat,
                Sender = Sender,
                SentAt = DateTime.Now,
                Message = messageInput,
                Recipient = FoundAppointment.PatientId

            };

            AppointmentId = FoundChat.AppointmentId;

            await _db.ChatMessages.AddAsync(MessageToSend);
            await _db.SaveChangesAsync();

            return AppointmentId;

            

        }


        public async Task EndChat(int ChatId)
        {
            var FoundChat = await GetChatById(ChatId);

            if (FoundChat is null)
                return;

            FoundChat.Status = ChatStatus.Closed;
            FoundChat.appointment.Status = AppointmentStatus.Completed;

            await _db.SaveChangesAsync();
        }

    }
}
