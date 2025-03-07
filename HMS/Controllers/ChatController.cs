using HMS.Interface;
using HMS.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HMS.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task<IActionResult> chat(int source)
        {
            var currentChat = await _chatService.GetChatById(source);
            var chatMembers = await _chatService.GetChatMembers(source);

            // Get the logged-in user's ID
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Check if the user is in the chat
            bool isParticipant = await _chatService.IsParticipant(source, userId);

            if (!isParticipant)
                return Forbid(); // 403 Forbidden 

            return View(currentChat);
        }


        public async Task<IActionResult> CreateChat(int source, UserType userType)
        {
            if (ModelState.IsValid)
            {
                // Attempt to create or find an existing chat
                var result = await _chatService.CreateChat(userType, source);

                if (result == 0)
                {
                    return RedirectToAction("Doctor", "Index");
                }

                return RedirectToAction("chat", new { source = result, appointmentId = source, userType });
            }

            return RedirectToAction("Doctor", "Index");
        }


        public async Task<IActionResult> SendMessageAction(int ChatId, string Sender, string messageInput, int AppointmentId)
        {
          
                var result = await _chatService.SendMessage(ChatId, Sender, messageInput, AppointmentId);

                if (result == 0)
                {
                   
                    TempData["ErrorMessage"] = "Failed to send the message.";
                    return RedirectToAction("Chat", new { source = ChatId, appointmentId = AppointmentId, userType = Sender });
                }

                //  everything is successful
                return RedirectToAction("Chat", new { source = ChatId, appointmentId = AppointmentId, userType = Sender });
        


            //return RedirectToAction("Chat", new { source = ChatId, appointmentId = AppointmentId, userType = Sender });
        }

        public async Task<IActionResult> EndChat(int ChatId)
        {

            await _chatService.EndChat(ChatId);
            return RedirectToAction("Index", "Doctor");


        }

    }
}
