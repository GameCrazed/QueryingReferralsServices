using System;
using NLog;

namespace Querying.Referrals.Services.Applications.Services.NLogServices
{
    public class NLogService : INLogService
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Logs an exception error to PaperTrail.
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="errorMessage">string</param>
        public void LogError(Exception ex, string errorMessage)
        {
            _logger.Error(ex, errorMessage);
        }
    }
}