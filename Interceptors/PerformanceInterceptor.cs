using System.Data.Common;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Gho_Daung___Order___Inventory_System__.Interceptors
{
    public class PerformanceInterceptor : DbCommandInterceptor
    {
        private const long SlowQueryThresholdMs = 200;

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result,
            CancellationToken cancellation = default )
        {
            var stopwatch =  Stopwatch.StartNew();
            stopwatch.Stop();           
            
            return base.ReaderExecutingAsync( command, eventData, result, cancellation );
        }
        public override ValueTask<DbDataReader> ReaderExecutedAsync(
            DbCommand command,
            CommandExecutedEventData eventData,
            DbDataReader result,
            CancellationToken cancellationToken = default)
        {
            double elapseMilliseconds = eventData.Duration.TotalMilliseconds;

            if (eventData.Duration.TotalMilliseconds > SlowQueryThresholdMs)
            {
                Console.WriteLine($"SLoW QUERY DETECTED ({eventData.Duration.TotalMilliseconds}:{command.CommandText})");
            }

            return base.ReaderExecutedAsync( command, eventData, result, cancellationToken );
        }
    }
}
