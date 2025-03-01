using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using HMS.DB;

public class AppointmentCleanupService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public AppointmentCleanupService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await DeleteOutdatedAppointments();
            await Task.Delay(TimeSpan.FromHours(24), stoppingToken); // Runs every 24 hours
        }
    }

    private async Task DeleteOutdatedAppointments()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContextion>();

            var twoDaysAgo = DateTime.UtcNow.AddDays(-2); // Set threshold for outdated appointments

            // Find outdated appointments
            var appointmentsToDelete = await dbContext.Appointments
                .Where(a => a.AppointmentDate < twoDaysAgo) // Compare only the date part, ignoring time
                .ToListAsync();

            foreach (var appointment in appointmentsToDelete)
            {
                // Delete related notifications first
                var notificationsToDelete = await dbContext.Notifications
                    .Where(n => n.AppointmentId == appointment.Id)
                    .ToListAsync();

                if (notificationsToDelete.Any())
                {
                    dbContext.Notifications.RemoveRange(notificationsToDelete);
                    await dbContext.SaveChangesAsync();
                }

                // Remove the appointment after its related notifications are gone
                dbContext.Appointments.Remove(appointment);
            }

            await dbContext.SaveChangesAsync();
        }
    }


}
