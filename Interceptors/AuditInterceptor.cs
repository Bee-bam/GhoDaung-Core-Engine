using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Gho_Daung___Order___Inventory_System__.Models;

namespace Gho_Daung___Order___Inventory_System__.Interceptors
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default
            )
        {
            var context = eventData.Context;

            if (context == null) return base.SavingChangesAsync(eventData, result, cancellationToken);

            var entries = context.ChangeTracker.Entries<IAuditable>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.Created_Date = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.Modified_Date = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Deleted && entry.Entity is ISoftDelete softDeleteEntity)
                {
                    entry.State = EntityState.Modified;
                    softDeleteEntity.IsDeleted = true;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
