using System;

namespace Querying.Referrals.Services.Applications.Services.NLogServices
{
    public interface INLogService
    {
        /// <summary>
        /// Logs an exception error to PaperTrail.
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="errorMessage">string</param>
        void LogError(Exception ex, string errorMessage);
    }
}