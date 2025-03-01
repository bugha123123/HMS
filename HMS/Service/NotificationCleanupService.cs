using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HMS.DB;

public class NotificationCleanupService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public NotificationCleanupService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await DeleteOutdatedNotifications();
            await Task.Delay(TimeSpan.FromHours(24), stoppingToken); // Runs every 24 hours
        }
    }

    private async Task DeleteOutdatedNotifications()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContextion>();

            var twoDaysAgo = DateTime.UtcNow.AddDays(-5); // two days ago

            // Find outdated notifications (created more than 2 days ago)
            var outdatedNotifications = await dbContext.Notifications
                .Where(n => n.CreatedAt <= twoDaysAgo)
                .ToListAsync();

            if (outdatedNotifications.Any())
            {
                dbContext.Notifications.RemoveRange(outdatedNotifications);
                await dbContext.SaveChangesAsync(); // Persist the changes
            }
        }
    }
}
