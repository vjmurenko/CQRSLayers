using System.Threading;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Interfaces
{
    public interface IDbContext : IReadOnlyDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}