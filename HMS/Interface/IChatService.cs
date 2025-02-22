using HMS.Model;

namespace HMS.Interface
{
    public interface IChatService
    {

        Task<int> CreateChat(UserType userType, int appId);

        Task<Chat> GetChatById(int ChatId);

        Task<Chat> IsChatAlreadyCreated(int appId);

        Task<bool> IsChatOpen(int AppointmentId);



    }
}
