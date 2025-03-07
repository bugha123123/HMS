using HMS.Model;

namespace HMS.Interface
{
    public interface IChatService
    {

        Task<int> CreateChat(UserType userType, int appId);

        Task<Chat> GetChatById(int ChatId);

        Task<Chat> IsChatAlreadyCreated(int appId);

        Task<bool> IsChatOpen(int AppointmentId);

        Task<int> SendMessage(int ChatId, string Sender,string messageInput, int AppointmentId);

        Task<List<ChatMessage>> GetSameChatMessages(int chatId);

        Task EndChat(int ChatId);

        Task<List<ChatMember>> GetChatMembers(int ChatId);

        Task<bool> IsParticipant(int ChatId, string UserId);



    }
}
