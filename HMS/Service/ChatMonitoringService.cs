using HMS.DB;
using HMS.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class ChatMonitoringService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public ChatMonitoringService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await CloseStaleChats();
            await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken); // Runs every 15 minutes
        }
    }

    private async Task CloseStaleChats()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContextion>();

            // Get all chats that are older than 1.5 hours and still not closed
            var chatsToCheck = await dbContext.Chats
                .Where(chat => chat.Status != ChatStatus.Closed &&
                               chat.CreatedAt <= DateTime.Now.AddHours(-1.5))
                .ToListAsync();

            if (chatsToCheck.Any())
            {
                foreach (var chat in chatsToCheck)
                {
                    chat.Status = ChatStatus.Closed;
                    chat.appointment.Status = AppointmentStatus.Completed;
                    dbContext.Chats.Update(chat);
                }

                // Save changes to the database
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
