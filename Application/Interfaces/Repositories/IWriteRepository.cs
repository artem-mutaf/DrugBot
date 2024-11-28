using Microsoft.AspNetCore.OData.Query;

namespace Application.Interfaces.Repositories;

public interface IWriteRepository<T> where T : class
{
    IReadOnlyList<T> ReadRepository { get; }
    
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    
    Task DeleteAsync(Guid Id, CancellationToken cancellationToken = default);
}