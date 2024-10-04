using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FuncAppTableStorageBackup
{
    public class BackupTables
    {
        private readonly ILogger _logger;

        public BackupTables(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BackupTables>();
        }

        [Function("BackupTables")]
        public void Run([TimerTrigger("0 1 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
