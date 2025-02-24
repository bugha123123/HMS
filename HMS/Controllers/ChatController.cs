using HMS.Interface;
using HMS.Model;
using Microsoft.AspNetCore.Mvc;
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
            var CurrentChat = await _chatService.GetChatById(source);
            return View(CurrentChat);
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
