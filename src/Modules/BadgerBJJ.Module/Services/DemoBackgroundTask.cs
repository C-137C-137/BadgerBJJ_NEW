using BadgerBJJ.Module.Indexes;
using BadgerBJJ.Module.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OrchardCore.BackgroundTasks;
using OrchardCore.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesSql;
using YesSql.Filters;

namespace BadgerBJJ.Module.Services
{
    //cron scheduler, per hour
    [BackgroundTask(Schedule = "0 * * * *", Description = "Hourly schedule maintenance task")]
    public class ScheduleMaintenanceTask : IBackgroundTask
    {
        private readonly ILogger<ScheduleMaintenanceTask> _logger;

        public ScheduleMaintenanceTask(ILogger<ScheduleMaintenanceTask> logger)
        {
            _logger = logger;
        }

        public async Task DoWorkAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            try
            {
                var session = serviceProvider.GetRequiredService<YesSql.ISession>();
                var clock = serviceProvider.GetRequiredService<IClock>();

                var outdatedSchedules = await session
                    .QueryIndex<ScheduleIndex>(index => index.AppointmentDate < clock.UtcNow)
                    .ListAsync();

                foreach (var schedule in outdatedSchedules)
                {
                    schedule.Status = "Completed";
                    await session.SaveAsync(schedule);
                }

                _logger.LogInformation(
                    "Schedule maintenance completed. Processed {Count} outdated schedules.",
                    outdatedSchedules.Count());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during schedule maintenance task");
            }
        }
    }
}
