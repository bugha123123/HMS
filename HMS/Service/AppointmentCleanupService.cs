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
            var yesterday = DateTime.UtcNow.Date.AddDays(-1);

            var outdatedAppointments = await dbContext.Appointments
                .Where(a => a.AppointmentDate < yesterday)
                .ToListAsync();

            if (outdatedAppointments.Any())
            {
                dbContext.Appointments.RemoveRange(outdatedAppointments);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
